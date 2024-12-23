using System.Xml.Linq;
using System.Xml.Schema;
using MedicalExaminationPreliminaryLists.Api.Application.Mappers;
using MedicalExaminationPreliminaryLists.Data.Models;
using MedicalExaminationPreliminaryLists.Infrastructure.Repositories;
using MedicalExaminationPreliminaryLists.Share.DTOs;
using MedicalExaminationPreliminaryLists.Share.Helpers;
using TFOMSUploadServer.Infrastructure.Repositories;

namespace MedicalExaminationPreliminaryLists.Api.Application.Services
{
    public class UploadMedicalExaminationPreliminaryListService : IUploadService
    {
        private readonly IZAPMainRecordRepository _zapRepository;
        private readonly IDispensaryObservationRepository _dispensaryObservationRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IUploadFileRepository _uploadFileRepository;
        private readonly IDiagnosisRepository _diagnosisRepository;
        private readonly IMedProfileRepository _medProfileRepository;


        public UploadMedicalExaminationPreliminaryListService(IZAPMainRecordRepository zapRepository,
            IDispensaryObservationRepository dispensaryObservationRepository,
            IPersonRepository personRepository,
            IUploadFileRepository uploadFileRepository,
            IDiagnosisRepository diagnosisRepository,
            IMedProfileRepository medProfileRepository)
        {
            _zapRepository = zapRepository;
            _dispensaryObservationRepository = dispensaryObservationRepository;
            _personRepository = personRepository;
            _uploadFileRepository = uploadFileRepository;
            _diagnosisRepository = diagnosisRepository;
            _medProfileRepository = medProfileRepository;
        }

        public void UploadFile (string filePath)
        {
            var schemePath = Path.Combine(Directory.GetCurrentDirectory(), "Files/Schemes", "MedicalExaminationPreliminaryListsScheme.xsd");

            XmlValidationHelper.ValidateBySchema(schemePath, filePath);

            MedicalExaminationPreliminaryListParse parser = new();    
            XDocument xdoc = XDocument.Load(filePath);
            XElement? dnRoot = xdoc.Element("DN");

            if (dnRoot is not null)
            {
                UploadFile uploadFile = new();
                
                uploadFile.FileName = dnRoot.Element("FNAME").Value;
                uploadFile.FilePath = filePath;
                uploadFile.UploadDate = DateTime.Now;

                _uploadFileRepository.Add(uploadFile);

                foreach (XElement zapElement in dnRoot.Elements("ZAP"))
                {
                    ZAPMainRecordModel zapDTO = parser.GetZAP(zapElement);

                    ZAPMainRecord zap = zapDTO.ToEntity();

                    zap.UploadFileId = uploadFile.Id;
                    zap.UploadFile = uploadFile;

                    zap.PersonId = _personRepository.First(p =>
                        p.Surname == zap.Surname && p.Name1 == zap.Name1 && p.Name2 == zap.Name2 && p.Birthday == zap.Birthday)?.Id ?? Guid.Empty;

                    _zapRepository.Add(zap);

                    foreach (XElement dn in zapElement.Elements("DN"))
                    {
                        DispensaryObservationModel dispensaryObservationDTO = parser.GetDispensaryObservation(dn);

                        DispensaryObservation dispensaryObservationNew = dispensaryObservationDTO.ToEntity();

                        dispensaryObservationNew.ZAPMainRecordId = zap.Id;
                        dispensaryObservationNew.ZAP = zap;
                        dispensaryObservationNew.LpuType = LpuHelper.SetLpu(dispensaryObservationNew.DiagnosisCode);

                        dispensaryObservationNew.DiagnosisId = _diagnosisRepository.First(d => d.Code == dispensaryObservationNew.DiagnosisCode).Id;

                        dispensaryObservationNew.MedProfileId = _medProfileRepository.First(m => m.Code == dispensaryObservationNew.MedProfileId).Id;

                        _dispensaryObservationRepository.Add(dispensaryObservationNew);
                    }
                }

                _uploadFileRepository.Save();
                _zapRepository.Save();
                _dispensaryObservationRepository.Save();
            }
        }
    }
}

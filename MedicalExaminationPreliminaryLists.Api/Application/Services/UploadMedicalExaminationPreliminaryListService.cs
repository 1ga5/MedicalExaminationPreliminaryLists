using System.Xml.Linq;
using System.Xml.Schema;
using MedicalExaminationPreliminaryLists.Api.Application.Mappers;
using MedicalExaminationPreliminaryLists.Data.Models;
using MedicalExaminationPreliminaryLists.Infrastructure.Repositories;
using MedicalExaminationPreliminaryLists.Share.DTOs;
using MedicalExaminationPreliminaryLists.Share.Helpers;

namespace MedicalExaminationPreliminaryLists.Api.Application.Services
{
    public class UploadMedicalExaminationPreliminaryListService : IUploadService
    {
        private readonly IZAPRepository _zapRepository;
        private readonly IDispensaryObservationRepository _dispensaryObservationRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IUploadFileRepository _uploadFileRepository;


        public UploadMedicalExaminationPreliminaryListService(IZAPRepository zapRepository,
            IDispensaryObservationRepository dispensaryObservationRepository,
            IPersonRepository personRepository,
            IUploadFileRepository uploadFileRepository)
        {
            _zapRepository = zapRepository;
            _dispensaryObservationRepository = dispensaryObservationRepository;
            _personRepository = personRepository;
            _uploadFileRepository = uploadFileRepository;
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
                    ZAPModel zapDTO = parser.GetZAP(zapElement);

                    ZAP zap = zapDTO.ToEntity();

                    zap.UploadFileId = uploadFile.Id;
                    zap.UploadFile = uploadFile;

                    zap.PersonId = _personRepository.First(p =>
                        p.Surname == zap.Surname && p.Name1 == zap.Name1 && p.Name2 == zap.Name2 && p.Birthday == zap.Birthday)?.Id ?? Guid.Empty;

                    _zapRepository.Add(zap);

                    foreach (XElement dn in zapElement.Elements("DN"))
                    {
                        DispensaryObservationModel dispensaryObservationDTO = parser.GetDispensaryObservation(dn);

                        DispensaryObservation dispensaryObservationNew = dispensaryObservationDTO.ToEntity();

                        dispensaryObservationNew.ZAPId = zap.Id;
                        dispensaryObservationNew.ZAP = zap;
                        dispensaryObservationNew.LpuType = LpuHelper.SetLpu(dispensaryObservationNew.DiagnosisCode);

                        _dispensaryObservationRepository.Add(dispensaryObservationNew);
                    }
                }

                _uploadFileRepository.Save();
                _zapRepository.Save();
                _dispensaryObservationRepository.Save();
            }
        }
        static void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            if (e.Severity == XmlSeverityType.Error)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
            else if (e.Severity == XmlSeverityType.Warning)
            {
                Console.WriteLine("Warning: {0}", e.Message);
            }
            else
            {
                Console.WriteLine("Ok");
            }
        }
    }
}

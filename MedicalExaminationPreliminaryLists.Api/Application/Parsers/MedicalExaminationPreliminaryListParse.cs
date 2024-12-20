using MedicalExaminationPreliminaryLists.Share.DTOs;
using MedicalExaminationPreliminaryLists.Share.Helpers;
using System.Xml.Linq;

namespace MedicalExaminationPreliminaryLists.Api.Application
{
    public class MedicalExaminationPreliminaryListParse : IMedicalExaminationPreliminaryListParse
    {
        public ZAPMainRecordModel GetZAP(XElement zap)
        {
            ZAPMainRecordModel zapModel = new ZAPMainRecordModel();

            zapModel.ZAPNumber = zap.Element("N_ZAP").GetIntOrDefault();
            zapModel.Year = zap.Element("YEAR").GetStringOrDefault();
            zapModel.Surname = zap.Element("FAM").GetStringOrDefault();
            zapModel.Name1 = zap.Element("IM").GetStringOrDefault();
            zapModel.Name2 = zap.Element("OT").GetStringOrDefault();
            zapModel.Birthday = zap.Element("DR").GetDateTimeOrDefault();
            zapModel.TelephoneNumber = zap.Element("TEL").GetStringOrDefault();

            return zapModel;
        }

        public DispensaryObservationModel GetDispensaryObservation(XElement dn)
        {
            DispensaryObservationModel dispensaryObservationModel = new DispensaryObservationModel();

            dispensaryObservationModel.Number = dn.Element("IDCASE").GetIntOrDefault();
            dispensaryObservationModel.MedProfileId = dn.Element("PROFIL").GetIntOrDefault();
            dispensaryObservationModel.DiagnosisId = dn.Element("DS").GetIntOrDefault();

            var beginDate = dn.Element("D_BEG");
            dispensaryObservationModel.BeginDate =  string.IsNullOrEmpty(beginDate?.Value) ? DateTime.MinValue : beginDate.GetDateTimeOrDefault();

            var endDate = dn.Element("D_END");
            dispensaryObservationModel.EndDate = string.IsNullOrEmpty(endDate?.Value) ? DateTime.MaxValue : endDate.GetDateTimeOrDefault();
            dispensaryObservationModel.EndReason = dn.Element("END_RES").GetStringOrDefault();

            return dispensaryObservationModel;
        }
    }
}

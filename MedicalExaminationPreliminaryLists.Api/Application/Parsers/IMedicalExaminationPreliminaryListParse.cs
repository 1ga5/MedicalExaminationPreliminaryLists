using MedicalExaminationPreliminaryLists.Data.Models;
using MedicalExaminationPreliminaryLists.Share.DTOs;
using System.Xml.Linq;

namespace MedicalExaminationPreliminaryLists.Api.Application
{
    public interface IMedicalExaminationPreliminaryListParse
    {
        ZAPMainRecordModel GetZAP(XElement element);
        DispensaryObservationModel GetDispensaryObservation (XElement element);
    }
}

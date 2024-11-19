using System.Xml.Linq;
using MedicalExaminationPreliminaryLists.Api.Application.Mappers;
using MedicalExaminationPreliminaryLists.Data.Models;
using MedicalExaminationPreliminaryLists.Share.DTOs;

namespace MedicalExaminationPreliminaryLists.Api.Application.Services
{
    public class MedicalExaminationPreliminaryListReader
    {
        static MedicalExaminationPreliminaryListParse parser = new();

        public static List<ZAP> ReadFromXML (string filePath)
        {
            List<ZAP> zapList = [];

            XDocument xdoc = XDocument.Load(filePath);
            XElement? dnRoot = xdoc.Element("DN");
            if (dnRoot is not null)
            {
                foreach (XElement zap in dnRoot.Elements("ZAP"))
                {
                    ZAPModel zapDTO = parser.GetZAP(zap);

                    ZAP zapNew = zapDTO.ToEntity();

                    foreach (XElement dn in zap.Elements("DN"))
                    {
                        DispensaryObservationModel dispensaryObservationDTO = parser.GetDispensaryObservation(dn);

                        DispensaryObservation dispensaryObservationNew = dispensaryObservationDTO.ToEntity();

                        dispensaryObservationNew.ZAPNumber = zapNew.ZAPNumber;
                        //dispensaryObservationNew.ZAP = zapNew;

                        Console.WriteLine(zapNew.ZAPNumber);
                        Console.WriteLine(dispensaryObservationNew.Number);

                        zapNew.Dispenses.Add(dispensaryObservationNew);
                    }

                    zapList.Add(zapNew);
                }
            }
            return zapList;
        }
    }
}

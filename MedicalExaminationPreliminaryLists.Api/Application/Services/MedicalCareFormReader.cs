using MedicalExaminationPreliminaryLists.Data.Models.Dictionaries;
using System.Xml.Linq;


namespace MedicalCareForm.Api.Services
{
    public class MedicalCareFormReader
    {
        public List<MedProfile> ReadFromXml(string filePath)
        {
            List<MedProfile> medicalCareFormList = [];
            XDocument xdoc = XDocument.Load(filePath);
            XElement? packet = xdoc.Element("packet");
            if (packet is not null)
            {
                foreach (XElement zap in packet.Elements("zap"))
                {
                    var codeValue = zap.Element("IDPR")?.Value;
                    var nameValue = zap.Element("PRNAME")?.Value;
                    var beginDateValue = zap.Element("DATEBEG")?.Value;
                    var endDateValue = zap.Element("DATEEND")?.Value;

                    medicalCareFormList.Add(new MedProfile
                    {
                        Code = string.IsNullOrEmpty(codeValue) ? 0 : int.Parse(codeValue),
                        Name = string.IsNullOrEmpty(nameValue) ? "unknown" : nameValue,
                        BeginDate = string.IsNullOrWhiteSpace(beginDateValue) ? DateTime.MinValue : DateTime.Parse(beginDateValue),
                        EndDate = string.IsNullOrWhiteSpace(endDateValue) ? DateTime.MaxValue : DateTime.Parse(endDateValue)
                    });
                }
            }

            return medicalCareFormList;
        }
    }
}


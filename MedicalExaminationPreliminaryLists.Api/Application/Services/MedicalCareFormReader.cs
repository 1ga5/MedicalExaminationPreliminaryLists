using MedicalExaminationPreliminaryLists.Data.Models.Dictionaries;
using System.Xml.Linq;


namespace MedicalCareForm.Api.Services
{
    public class MedicalCareFormReader
    {
        public List<Diagnosis> ReadFromXml(string filePath)
        {
            List<Diagnosis> medicalCareFormList = [];
            XDocument xdoc = XDocument.Load(filePath);
            XElement? book = xdoc.Element("book");
            XElement? entries = book.Element("entries");
            if (book is not null)
            {
                foreach (XElement zap in entries.Elements("entry"))
                {
                    var id = zap.Element("ID")?.Value;
                    var codeValue = zap.Element("MKB_CODE")?.Value;
                    var nameValue = zap.Element("MKB_NAME")?.Value;
                    var parentId = zap.Element("ID_PARENT")?.Value;
                    var isActual = zap.Element("ACTUAL")?.Value;

                    medicalCareFormList.Add(new Diagnosis
                    {
                        Id = string.IsNullOrWhiteSpace(id) ? 0 : int.Parse(id),
                        Code = string.IsNullOrEmpty(codeValue) ? "" : codeValue,
                        Name = string.IsNullOrEmpty(nameValue) ? "unknown" : nameValue,
                        ParentId = string.IsNullOrWhiteSpace(parentId) ? 0 : int.Parse(parentId),
                        IsActual = isActual == "1" ? true : false
                    });
                }
            }

            return medicalCareFormList;
        }
    }
}


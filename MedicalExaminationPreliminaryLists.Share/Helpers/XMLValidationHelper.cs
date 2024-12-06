using System.Xml;
using System.Xml.Schema;

namespace MedicalExaminationPreliminaryLists.Share.Helpers
{
    public class XmlValidationHelper
    {
        public static void ValidateBySchema(string schemaPath, string filePath)
        {
            List<string> validationErrors = new List<string>();

            XmlReaderSettings settings = new XmlReaderSettings();
            settings.Schemas.Add(null, schemaPath);
            settings.ValidationType = ValidationType.Schema;
            settings.ValidationEventHandler += new ValidationEventHandler((sender, args) => ValidationCallBack(args, validationErrors));

            XmlReader reader = XmlReader.Create(filePath, settings);

            while (reader.Read()) ;

            if (validationErrors.Count > 0) 
            {
                throw new XmlSchemaValidationException("Ошибка валидации:\n" + string.Join(Environment.NewLine, validationErrors));
            }
        }

        private static void ValidationCallBack(ValidationEventArgs args, List<string> validationErrors)
        {
            if (args.Severity == XmlSeverityType.Warning)
            {
                Console.WriteLine("Warning: " + args.Message);
                validationErrors.Add(args.Message);
            }
            else
            {
                Console.WriteLine("Error: " + args.Message);
                validationErrors.Add(args.Message);
            }
        }
    }
}

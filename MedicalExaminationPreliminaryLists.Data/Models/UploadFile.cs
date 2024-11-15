using MedicalExaminationPreliminaryLists.Data.Common;

namespace MedicalExaminationPreliminaryLists.Data.Models
{
    public class UploadFile : BaseGUIDEntity
    {
        public string FileName { get; set; } = string.Empty;

        public string FilePath { get; set; } = string.Empty;

        public DateTime UploadDate {  get; set; }

    }
}

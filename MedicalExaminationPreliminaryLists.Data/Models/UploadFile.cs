using MedicalExaminationPreliminaryLists.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace MedicalExaminationPreliminaryLists.Data.Models
{
    public class UploadFile : BaseGUIDEntity
    {
        [Display(Name = "Название файла")]
        public string FileName { get; set; } = string.Empty;

        [Display(Name = "Путь к файлу")]
        public string FilePath { get; set; } = string.Empty;

        [Display(Name = "Дата загрузки")]
        public DateTime UploadDate {  get; set; }
    }
}

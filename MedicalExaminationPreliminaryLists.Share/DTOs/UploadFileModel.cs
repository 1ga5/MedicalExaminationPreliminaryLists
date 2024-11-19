using System.ComponentModel.DataAnnotations;

namespace MedicalExaminationPreliminaryLists.Share.DTOs
{
    public class UploadFileModel : BaseGUIDModel
    {
        [Display(Name = "Название файла")]
        public string FileName { get; set; } = string.Empty;

        [Display(Name = "Путь к файлу")]
        public string FilePath { get; set; } = string.Empty;

        [Display(Name = "Дата загрузки")]
        public DateTime UploadDate { get; set; }
    }
}

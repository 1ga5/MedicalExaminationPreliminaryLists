using System.ComponentModel.DataAnnotations;

namespace MedicalExaminationPreliminaryLists.Share.DTOs
{
    public class ZAPModel : BaseGUIDModel
    {
        [Display(Name = "Номер записи")]
        public int ZAPNumber { get; set; }
        public string LpuType { get; set; } = string.Empty;

        [Display(Name = "Год")]
        public string Year { get; set; } = string.Empty;

        [Display(Name = "Id гражданина из ФЕРЗЛ")]
        public Guid PersonId { get; set; }

        [Display(Name = "Фамилия")]
        public string Surname { get; set; } = string.Empty;

        [Display(Name = "Имя")]
        public string Name1 { get; set; } = string.Empty;

        [Display(Name = "Отчество")]
        public string Name2 { get; set; } = string.Empty;

        [Display(Name = "Дата рождения")]
        public DateTime Birthday { get; set; }

        [Display(Name = "Номер телефона")]
        public string TelephoneNumber { get; set; } = string.Empty;

        public ZAPModel()
        {
            Id = Guid.NewGuid();
        }
    }
}

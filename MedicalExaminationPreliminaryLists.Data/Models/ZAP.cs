using MedicalExaminationPreliminaryLists.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace MedicalExaminationPreliminaryLists.Data.Models
{
    public class ZAP : BaseGUIDEntity
    {
        [Display(Name = "Номер записи")]
        public int ZAPNumber { get; set; }

        [Display(Name = "Id загруженного файла")]
        public Guid UploadFileId { get; set; }
        
        [Display(Name = "Код лечебно-профилактического учреждения")]
        public string LpuType { get; set; } = string.Empty;

        [Display(Name = "Год")]
        public string Year { get; set; } = string.Empty;

        [Display(Name = "Id гражданина из ФЕРЗЛ")]
        public Guid PersonId { get; set; }

        [Display(Name = "Ссылка на объект Person")]
        public virtual Person? Person { get; set; }

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
        
        [Display(Name = "Список диспансерных наблюдений")]
        public virtual List<DispensaryObservation>? Dispenses { get; set; }
    }
}

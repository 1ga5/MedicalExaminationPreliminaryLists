using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalExaminationPreliminaryLists.Data.Common
{
    public class DictionaryBaseType<T> : BaseEntity
    {
        [Display(Name = "Код")]
        public T Code { get; set; } = default!;
        [Column(TypeName = "date")]
        [Display(Name = "Начало")]
        public DateTime BeginDate { get; set; }

        [Display(Name = "Окончание")]
        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }
        [MaxLength(350)]
        [Display(Name = "Наименование")]
        public string Name { get; set; } = string.Empty;
        [MaxLength(350)]
        public string Comments { get; set; } = string.Empty;

        public DictionaryBaseType()
        {
        }

    }
}

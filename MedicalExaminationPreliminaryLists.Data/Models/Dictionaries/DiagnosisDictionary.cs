using System.ComponentModel.DataAnnotations;
using MedicalExaminationPreliminaryLists.Data.Common;

namespace MedicalExaminationPreliminaryLists.Data.Models.Dictionaries
{
    /// <summary>
    /// Классификатор болезней МКБ-10(диагнозов). В НСИ МИНЗДРАВ справочник M001
    /// </summary>
    public class DiagnosisDictionary : BaseEntity
    {
        [Display(Name = "Код МКБ")]
        public string Code { get; set; } = string.Empty;
        [Display(Name = "Наименование")]
        public string Name { get; set; } = string.Empty;
        [Display(Name = "Код родительской записи")]
        public int ParentId { get; set; }
        [Display(Name = "Признак актуальности")]
        public bool IsActual { get; set; }
    }
}

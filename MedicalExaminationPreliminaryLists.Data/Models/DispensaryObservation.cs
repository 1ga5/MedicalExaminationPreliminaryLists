using MedicalExaminationPreliminaryLists.Data.Common;
using MedicalExaminationPreliminaryLists.Data.Models.Dictionaries;
using System.ComponentModel.DataAnnotations;

namespace MedicalExaminationPreliminaryLists.Data.Models
{
    public class DispensaryObservation : BaseEntity
    {
        [Display(Name = "Порядковый номер")]
        public int Number { get; set; }

        [Display(Name = "Id профиля медицинской помощи")]
        public int MedProfileId { get; set; }

        [Display(Name = "Ссылка на объект MedProfile")]
        public virtual MedProfile? MedProfile { get; set; }

        [Display(Name = "Код лечебно-профилактического учреждения")]
        public string LpuType { get; set; } = string.Empty;

        [Display(Name = "Id болезни")]
        public int DiagnosisId { get; set; }
        
        [Display(Name = "Ссылка на объект Diagnosis")]
        public virtual Diagnosis? Diagnosis { get; set; }
        
        [Display(Name = "Код болезни")]
        public string DiagnosisCode { get; set; } = string.Empty;

        [Display(Name = "Дата начала")]
        public DateTime BeginDate { get; set; }
        
        [Display(Name = "Дата конца")]
        public DateTime EndDate { get; set; }
        
        [Display(Name = "Причина прекращения")]
        public string EndReason { get; set; } = string.Empty;

        [Display(Name = "Id записи")]
        public Guid ZAPMainRecordId { get; set; }

        [Display(Name = "Ссылка на объект ZAP")]
        public virtual ZAPMainRecord? ZAP { get; set; }
    }
}

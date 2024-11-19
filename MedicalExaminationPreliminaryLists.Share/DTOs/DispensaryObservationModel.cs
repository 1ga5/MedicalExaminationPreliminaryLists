using System.ComponentModel.DataAnnotations;

namespace MedicalExaminationPreliminaryLists.Share.DTOs
{
    public class DispensaryObservationModel : BaseModel
    {
        [Display(Name = "Порядковый номер")]
        public int Number { get; set; }

        [Display(Name = "Id профиля медицинской помощи")]
        public int MedProfileId { get; set; }

        [Display(Name = "Код лечебно-профилактического учреждения")]
        public string LpuType { get; set; } = string.Empty;

        [Display(Name = "Код МКБ")]
        public string DiagnosisCode { get; set; } = string.Empty;

        [Display(Name = "Дата начала")]
        public DateTime BeginDate { get; set; }

        [Display(Name = "Дата конца")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Причина прекращения")]
        public string EndReason { get; set; } = string.Empty;

        [Display(Name = "Номер записи")]
        public int ZAPNumber { get; set; }
    }
}

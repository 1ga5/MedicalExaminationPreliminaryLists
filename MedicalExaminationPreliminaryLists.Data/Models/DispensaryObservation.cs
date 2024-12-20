﻿using MedicalExaminationPreliminaryLists.Data.Common;
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

        [Display(Name = "Ссылка на объект MedProfileDictionary")]
        public virtual MedProfileDictionary? MedProfileDictionary { get; set; }

        [Display(Name = "Код лечебно-профилактического учреждения")]
        public string LpuType { get; set; } = string.Empty;

        [Display(Name = "Код МКБ")]
        public string DiagnosisCode { get; set; } = string.Empty;
        
        [Display(Name = "Ссылка на объект DiagnosisDictionary")]
        public virtual DiagnosisDictionary? DiagnosisDictionary { get; set; }
        
        [Display(Name = "Дата начала")]
        public DateTime BeginDate { get; set; }
        
        [Display(Name = "Дата конца")]
        public DateTime EndDate { get; set; }
        
        [Display(Name = "Причина прекращения")]
        public string EndReason { get; set; } = string.Empty;

        [Display(Name = "Id записи")]
        public Guid ZAPId { get; set; }

        [Display(Name = "Ссылка на объект ZAP")]
        public virtual ZAP? ZAP { get; set; }
    }
}

﻿using System.ComponentModel.DataAnnotations;
using TFOMSReestrServer.DS.Common;
using TFOMSReestrServer.DS.Models;

namespace MedicalExaminationPreliminaryLists.Data.Models
{
    public class ZAP : BaseGUIDEntity
    {
        [Display(Name = "Номер записи")]
        public int ZAPNumber { get; set; }

        [Display(Name = "Год")]
        public DateTime Year { get; set; }

        [Display(Name = "Id гражданина из ФЕРЗЛ")]
        public int PersonId { get; set; }

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
    }
}

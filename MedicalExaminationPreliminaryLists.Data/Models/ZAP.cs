using System.ComponentModel.DataAnnotations;
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


    }
}

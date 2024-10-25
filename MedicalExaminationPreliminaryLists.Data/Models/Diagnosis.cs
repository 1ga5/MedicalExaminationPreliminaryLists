using MedicalExaminationPreliminaryLists.Data.Common;
using MedicalExaminationPreliminaryLists.Data.Models.Dictionaries;

namespace MedicalExaminationPreliminaryLists.Data.Models
{
    public class Diagnosis : BaseEntity
    {
        public int Number { get; set; }
        public int PersonId { get; set; }
        public virtual Person? Person { get; set; }
        public int MedProfileId { get; set; }
        public virtual MedProfileDictionary? MedProfileDictionary { get; set; }
        public int DiagnosisId { get; set; }
        public virtual DiagnosisDictionary? DiagnosisDictionary { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string EndReason { get; set; } = string.Empty;


    }
}

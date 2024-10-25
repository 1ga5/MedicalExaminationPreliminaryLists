using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedicalExaminationPreliminaryLists.Data.Common;

namespace MedicalExaminationPreliminaryLists.Data.Models
{
    public class Person : BaseEntity
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime Birthday { get; set; }
        public string TelephoneNumber { get; set; } = string.Empty;
    }
}

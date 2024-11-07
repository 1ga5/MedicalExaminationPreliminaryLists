using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MedicalExaminationPreliminaryLists.Data.Common
{
    public class BaseGUIDEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime CreateDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime EditDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DeleteDate { get; set; }
        public bool IsDeleted { get; set; }

        public BaseGUIDEntity()
        {
            CreateDate = DateTime.Today;
            EditDate = DateTime.Today;
            DeleteDate = DateTime.MaxValue;
            IsDeleted = false;
        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MedicalExaminationPreliminaryLists.Data.Common
{
    public class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime CreateDate { get; set; }
        public int EditUserId { get; set; }

        [Column(TypeName = "date")]
        public DateTime EditDate { get; set; }

        public int DeletedUserId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DeleteDate { get; set; }

        public bool IsDeleted { get; set; }

        public BaseEntity()
        {
            CreateDate = DateTime.Today;
            EditDate = DateTime.Today;
            DeleteDate = DateTime.MaxValue;
            DeletedUserId = 0;
            IsDeleted = false;
        }
    }
}

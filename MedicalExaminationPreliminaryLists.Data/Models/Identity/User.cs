using Microsoft.AspNetCore.Identity;

namespace MedicalExaminationPreliminaryLists.Data.Models.Identity
{
    public class User : IdentityUser
    {
        public string Name { get; set; } = string.Empty;
    }
}

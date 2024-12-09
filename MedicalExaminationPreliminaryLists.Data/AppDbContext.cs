using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MedicalExaminationPreliminaryLists.Data.Models;
using MedicalExaminationPreliminaryLists.Data.Models.Dictionaries;
using Microsoft.EntityFrameworkCore;
using MedicalExaminationPreliminaryLists.Data.Models.Identity;

namespace MedicalExaminationPreliminaryLists.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<UploadFile> UploadFiles => Set<UploadFile>();
        public DbSet<DiagnosisDictionary> DiagnosisDictionaries => Set<DiagnosisDictionary>();
        public DbSet<MedProfileDictionary> MedProfileDictionaries => Set<MedProfileDictionary>();
        public DbSet<Person> Persons => Set<Person>();
        public DbSet<ZAP> ZAPs => Set<ZAP>();
        public DbSet<DispensaryObservation> ExaminationDiagnoses => Set<DispensaryObservation>();
    }
}

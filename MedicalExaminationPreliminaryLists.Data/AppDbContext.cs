using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MedicalExaminationPreliminaryLists.Data.Models;
using MedicalExaminationPreliminaryLists.Data.Models.Dictionaries;
using Microsoft.EntityFrameworkCore;
using MedicalExaminationPreliminaryLists.Data.Models.Identity;
using System.Reflection.Metadata;

namespace MedicalExaminationPreliminaryLists.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ZAP>()
                .HasMany(e => e.Dispenses)
                .WithOne(e => e.ZAP)
                .HasForeignKey(e => e.ZAPId)
                .IsRequired();
        }

        public DbSet<UploadFile> UploadFiles => Set<UploadFile>();
        public DbSet<DiagnosisDictionary> DiagnosisDictionaries => Set<DiagnosisDictionary>();
        public DbSet<MedProfileDictionary> MedProfileDictionaries => Set<MedProfileDictionary>();
        public DbSet<Person> Persons => Set<Person>();
        public DbSet<ZAP> ZAPs => Set<ZAP>();
        public DbSet<DispensaryObservation> ExaminationDiagnoses => Set<DispensaryObservation>();
    }
}

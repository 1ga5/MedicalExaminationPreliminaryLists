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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ZAPMainRecord>()
                .HasMany(e => e.Dispenses)
                .WithOne(e => e.ZAP)
                .HasForeignKey(e => e.ZAPMainRecordId)
                .IsRequired();
        }

        public DbSet<UploadFile> UploadFiles => Set<UploadFile>();
        public DbSet<Diagnosis> DiagnosisDictionaries => Set<Diagnosis>();
        public DbSet<MedProfile> MedProfileDictionaries => Set<MedProfile>();
        public DbSet<Person> Persons => Set<Person>();
        public DbSet<ZAPMainRecord> ZAPMainRecords => Set<ZAPMainRecord>();
        public DbSet<DispensaryObservation> DispensaryObservations => Set<DispensaryObservation>();
    }
}

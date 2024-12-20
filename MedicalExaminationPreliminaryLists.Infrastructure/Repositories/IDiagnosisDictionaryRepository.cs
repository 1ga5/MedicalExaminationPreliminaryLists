using MedicalExaminationPreliminaryLists.Data;
using MedicalExaminationPreliminaryLists.Data.Models.Dictionaries;
using MedicalExaminationPreliminaryLists.Infrastructure.Common;

namespace MedicalExaminationPreliminaryLists.Infrastructure.Repositories
{
    public interface IDiagnosisRepository : IRepository<Diagnosis>, IDisposable
    {
    }

    //Репозиторий DiagnosisRepository, Наследник GenericRepository, реализует интерфейс IDiagnosisRepository
    public class DiagnosisRepository : GenericRepository<Diagnosis>, IDiagnosisRepository
    {
        public DiagnosisRepository(AppDbContext contextFactory) : base(contextFactory)
        {
        }
    }
}

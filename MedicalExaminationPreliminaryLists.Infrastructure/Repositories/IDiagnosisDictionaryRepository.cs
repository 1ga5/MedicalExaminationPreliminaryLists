using MedicalExaminationPreliminaryLists.Data;
using MedicalExaminationPreliminaryLists.Data.Models.Dictionaries;
using MedicalExaminationPreliminaryLists.Infrastructure.Common;

namespace MedicalExaminationPreliminaryLists.Infrastructure.Repositories
{
    public interface IDiagnosisDictionaryRepository : IRepository<DiagnosisDictionary>, IDisposable
    {
    }
    //Репозиторий DiagnosisDictionaryRepository, Наследник GenericRepository, реализует интерфейс IDiagnosisDictionaryRepository
    public class DiagnosisDictionaryRepository : GenericRepository<DiagnosisDictionary>, IDiagnosisDictionaryRepository
    {
        public DiagnosisDictionaryRepository(AppDbContext contextFactory) : base(contextFactory)
        {
        }
    }
}

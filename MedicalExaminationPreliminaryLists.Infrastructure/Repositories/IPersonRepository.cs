using MedicalExaminationPreliminaryLists.Data;
using MedicalExaminationPreliminaryLists.Data.Models;
using MedicalExaminationPreliminaryLists.Infrastructure.Common;

namespace MedicalExaminationPreliminaryLists.Infrastructure.Repositories
{
    public interface IPersonRepository : IGUIDRepository<Person>, IDisposable
    {
    }

    //Репозиторий PersonRepository, Наследник GenericRepository, реализует интерфейс IPersonRepository
    public class PersonRepository : GenericGUIDRepository<Person>, IPersonRepository
    {
        public PersonRepository(AppDbContext contextFactory) : base(contextFactory)
        {
        }
    }
}

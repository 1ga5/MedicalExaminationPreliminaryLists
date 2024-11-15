using MedicalExaminationPreliminaryLists.Data;
using MedicalExaminationPreliminaryLists.Data.Models;
using MedicalExaminationPreliminaryLists.Infrastructure.Common;

namespace MedicalExaminationPreliminaryLists.Infrastructure.Repositories
{
    public interface IZAPRepository : IGUIDRepository<ZAP>, IDisposable
    {
    }
    //Репозиторий IZAPRepository, Наследник GenericRepository, реализует интерфейс IZAPRepository
    public class ZAPRepository : GenericGUIDRepository<ZAP>, IZAPRepository
    {
        public ZAPRepository(AppDbContext contextFactory) : base(contextFactory)
        {
        }
    }
}

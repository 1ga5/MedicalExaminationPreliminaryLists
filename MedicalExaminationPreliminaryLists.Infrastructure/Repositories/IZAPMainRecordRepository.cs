using MedicalExaminationPreliminaryLists.Data;
using MedicalExaminationPreliminaryLists.Data.Models;
using MedicalExaminationPreliminaryLists.Infrastructure.Common;

namespace MedicalExaminationPreliminaryLists.Infrastructure.Repositories
{
    public interface IZAPMainRecordRepository : IGUIDRepository<ZAPMainRecord>, IDisposable
    {
    }

    //Репозиторий ZAPMainRecordRepository, Наследник GenericRepository, реализует интерфейс IZAPMainRecordRepository
    public class ZAPRepository : GenericGUIDRepository<ZAPMainRecord>, IZAPMainRecordRepository
    {
        public ZAPRepository(AppDbContext contextFactory) : base(contextFactory)
        {
        }
    }
}

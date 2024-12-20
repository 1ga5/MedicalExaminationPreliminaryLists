using MedicalExaminationPreliminaryLists.Data;
using MedicalExaminationPreliminaryLists.Data.Models;
using MedicalExaminationPreliminaryLists.Infrastructure.Common;

namespace MedicalExaminationPreliminaryLists.Infrastructure.Repositories
{
    public interface IUploadFileRepository : IGUIDRepository<UploadFile>, IDisposable
    {
    }

    //Репозиторий UploadFileRepository, Наследник GenericRepository, реализует интерфейс IUploadFileRepository
    public class UploadFileRepository : GenericGUIDRepository<UploadFile>, IUploadFileRepository
    {
        public UploadFileRepository(AppDbContext contextFactory) : base(contextFactory)
        {
        }
    }
}

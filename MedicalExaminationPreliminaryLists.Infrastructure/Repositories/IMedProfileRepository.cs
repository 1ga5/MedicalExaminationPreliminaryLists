using MedicalExaminationPreliminaryLists.Data;
using MedicalExaminationPreliminaryLists.Data.Models.Dictionaries;
using MedicalExaminationPreliminaryLists.Infrastructure.Common;

namespace TFOMSUploadServer.Infrastructure.Repositories
{
    public interface IMedProfileRepository : IRepository<MedProfile>, IDisposable
    {
    }

    //Репозиторий MedProfileRepository, Наследник GenericRepository, реализует интерфейс IMedProfileRepository
    public class MedProfileRepository : GenericRepository<MedProfile>, IMedProfileRepository
    {
        public MedProfileRepository(AppDbContext contextFactory) : base(contextFactory)
        {
        }
    }
}

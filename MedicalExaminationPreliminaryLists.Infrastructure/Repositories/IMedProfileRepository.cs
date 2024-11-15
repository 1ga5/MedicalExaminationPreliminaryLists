using MedicalExaminationPreliminaryLists.Data;
using MedicalExaminationPreliminaryLists.Data.Models.Dictionaries;
using MedicalExaminationPreliminaryLists.Infrastructure.Common;

namespace TFOMSUploadServer.Infrastructure.Repositories
{
    public interface IMedProfileDictionaryRepository : IRepository<MedProfileDictionary>, IDisposable
    {
    }
    //Репозиторий IMedProfileDictionaryRepository, Наследник GenericRepository, реализует интерфейс IMedProfileRepository
    public class MedProfileDictionaryRepository : GenericRepository<MedProfileDictionary>, IMedProfileDictionaryRepository
    {
        public MedProfileDictionaryRepository(AppDbContext contextFactory) : base(contextFactory)
        {
        }
    }
}

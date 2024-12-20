using MedicalExaminationPreliminaryLists.Data;
using MedicalExaminationPreliminaryLists.Infrastructure.Common;
using MedicalExaminationPreliminaryLists.Data.Models;

namespace MedicalExaminationPreliminaryLists.Infrastructure.Repositories
{
    public interface IDispensaryObservationRepository : IRepository<DispensaryObservation>, IDisposable
    {
    }

    //Репозиторий DispensaryObservationRepository, Наследник GenericRepository, реализует интерфейс IDispensaryObservationRepository
    public class DispensaryObservationRepository : GenericRepository<DispensaryObservation>, IDispensaryObservationRepository
    {
        public DispensaryObservationRepository(AppDbContext contextFactory) : base(contextFactory)
        {
        }
    }
}

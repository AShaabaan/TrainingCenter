using Castle.Core.Resource;
using Models;

namespace PresentationLayer.Repository
{
    public interface ITraineeRepository
    {
        Task<IEnumerable<Trainee>> GetAll();
        Task<Trainee> GetByID(int id);
        Task Update(int id, Trainee trainee);
        Task Delete(int id);
        Task<IEnumerable<CourseResult>> TrainesCrsResult(int id);
        

    }
}

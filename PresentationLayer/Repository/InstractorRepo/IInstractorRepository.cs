using Models;

namespace PresentationLayer.Repository
{
    public interface IInstractorRepository
    {
        Task<IEnumerable<Instractor>> GetAll();
        Task<Instractor> GetByID(int id);
        Task Update(int id, Instractor trainee);
        Task Delete(int id);
    }
}

using Models;
using PresentationLayer.ViewModels;

namespace PresentationLayer.Repository
{
    public interface IInstractorRepository
    {
        Task<IEnumerable<Instractor>> GetAll();
        Task<Instractor> GetByID(int id);
        Task Update(int id, Instractor instractor);
        Task Delete(int id);
        Task Create (Instractor instractor);
        bool IsExists(int id);

    }
}

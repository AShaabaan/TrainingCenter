using Microsoft.EntityFrameworkCore;
using Models;
using PresentationLayer.ViewModels;

namespace PresentationLayer.Repository.DepartmentRepo
{
    public interface IDepartmentRepositroy
    {
        Task<IEnumerable<Department>> GetAll();
        Task<Department> GetByID(int id);
        Task Update(int id, DepartmentViewModel department);
        Task Delete(int id);
        Task Create(DepartmentViewModel department);
        bool IsExists(int id);
    }
}

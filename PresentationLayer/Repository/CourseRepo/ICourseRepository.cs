using Microsoft.EntityFrameworkCore;
using Models;
using System.Collections.Generic;

namespace PresentationLayer.Repository.CourseRepo
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAll();
        Task<Course> GetByID(int id);
        Task Update(int id, Course course);
        Task Delete(int id);
        Task Create(Course course);
        bool IsExists(int id);
    }
}

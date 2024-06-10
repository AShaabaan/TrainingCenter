using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using PresentationLayer.ViewModels;

namespace PresentationLayer.Repository.CourseRepo
{
    public class CourseRepository : ICourseRepository
    {
        private readonly Center context;

        public CourseRepository(Center center)
        {
            this.context = center;
        }

        public Task Create(Course course)
        {
            context.Entry(course);
            context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Course>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Course> GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public bool IsExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, Course course)
        {
            throw new NotImplementedException();
        }
    }
}

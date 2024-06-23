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

        public async Task Delete(int id)
        {
            var Course = context.Courses.FirstOrDefaultAsync(c => c.Id == id);
            context.Remove(Course);
            context.SaveChanges();
        }

        public async Task<IEnumerable<Course>> GetAll()
        {
            return await context.Courses.ToListAsync();
        }

        public async Task<Course> GetByID(int id)
        {
            return await context.Courses.SingleOrDefaultAsync(x => x.Id == id);

        }

        public bool IsExists(int id)
        {
            return (context.Courses?.Any(e => e.Id == id)).GetValueOrDefault();

        }

        public async Task Update(int id, CourseViewModel NewCourse)
        {
            Course OldCourse= await GetByID(id);
            OldCourse.Name = NewCourse.Name;
            OldCourse.MinDegree = NewCourse.MinDegree;
            OldCourse.Degree = NewCourse.Degree;
            OldCourse.Dept_ID = NewCourse.Dept_ID;
            context.Update(OldCourse);
            context.SaveChanges();

        }
    }
}

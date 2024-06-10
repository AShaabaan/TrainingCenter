using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using PresentationLayer.ViewModels;

namespace PresentationLayer.Repository.DepartmentRepo
{
    public class DepartmentRepository : IDepartmentRepositroy
    {
        private readonly Center context;

        public DepartmentRepository(Center center)
        {
            this.context = center;
        }
        public async Task Delete(int id)
        {
            var department = await GetByID(id);
            context.Remove(department);
            context.SaveChanges();
        }

        public async Task<IEnumerable<Department>> GetAll()
        {
            var departments = await context.Department.ToListAsync();
            return departments;
        }

        public async Task<Department> GetByID(int id)
        {       
           return await context.Department.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(int id, DepartmentViewModel department)
        {
           Department OldDepartment =  await GetByID(id);
           OldDepartment.Name = department.Name;
           OldDepartment.Manager = department.Manager;
           context.Update(OldDepartment);
           context.SaveChanges();
        }

        public async Task Create(DepartmentViewModel department)
        {
            Department dept = new Department();
            dept.Name = department.Name;
            dept.Manager = department.Manager;
            context.Add(dept);
            context.SaveChanges();
        }

        public bool IsExists(int id)
        {
            return (context.Department?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

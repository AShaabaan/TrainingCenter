using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;
using PresentationLayer.Repository.DepartmentRepo;
using PresentationLayer.ViewModels;

namespace PresentationLayer.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepositroy repository;

        public DepartmentController(IDepartmentRepositroy departmentRepository)
        {
            this.repository = departmentRepository;
        }

        public async Task<IActionResult> Index()
        {
            var Departments = await repository.GetAll();
            if (Departments != null)
                return View(Departments);
            else
                ModelState.AddModelError("Error","Department Not Is Empty");
            return View(Departments);
        }

        // GET: Department/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await repository.GetByID(id);
            DepartmentViewModel viewModel = new DepartmentViewModel();
            viewModel.Id = id;
            viewModel.Name = department.Name;
            viewModel.Manager = department.Manager;
            if (department == null)
            {
                ModelState.AddModelError("Error", "Department Not Is Empty");
            }
            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DepartmentViewModel department)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await repository.Create(department);
                }
                catch (Exception ex) 
                {
                    return View(ex.Message);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var department = await repository.GetByID(id);
            DepartmentViewModel viewModel = new DepartmentViewModel();
            viewModel.Id = department.Id;
            viewModel.Name = department.Name;
            viewModel.Manager = department.Manager;
            if (department == null)
            {
                ModelState.AddModelError("Error", "Department Is Empty");
            }
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DepartmentViewModel department)
        {
            if (id != department.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await repository.Update(id, department);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IsExists(department.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        // GET: Department/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var department = await repository.GetByID(id);
            var Dept = new DepartmentViewModel();
            Dept.Name = department.Name;
            Dept.Manager = department.Manager;
            if (Dept == null)
            {
                return NotFound();
            }

            return View(Dept);
        }

        // POST: Department/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dept =  repository.GetByID(id);
            if (repository.GetByID(id) == null)
            {
                return Problem("Entity set 'Department'  is null.");
            }
            if (dept != null)
            {
                await repository.Delete(id);
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool IsExists(int id)
        {
          return (repository.IsExists(id));
        }
    }
}

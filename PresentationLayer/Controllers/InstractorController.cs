using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Models;
using PresentationLayer.Repository;
using PresentationLayer.Repository.CourseRepo;
using PresentationLayer.Repository.DepartmentRepo;
using PresentationLayer.ViewModels;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;

namespace PresentationLayer.Controllers
{
    public class InstractorController : Controller
    {
        private readonly IInstractorRepository repository;
        private readonly IDepartmentRepositroy departmentRepositroy;
        private readonly ICourseRepository courseRepository;

        public InstractorController(IInstractorRepository _repository,
                                    IDepartmentRepositroy departmentRepositroy,
                                    ICourseRepository courseRepository )
        {
            repository = _repository;
            this.departmentRepositroy = departmentRepositroy;
            this.courseRepository = courseRepository;
        }
        public async Task<IActionResult> Index()
        {

            var Instractors = await repository.GetAll();
            return View(Instractors);
        }

        public async Task<IActionResult> Details(int id)
        {
            Instractor instractor = await repository.GetByID(id);
            return View(instractor);
        }

        public async Task<IActionResult> Create()
        {
            var departments = await departmentRepositroy.GetAll();
            var courses = await courseRepository.GetAll();

            var viewModel = new InstructorViewModel
            {
                Departments = new SelectList(departments, "Id", "Name"),
                Courses = new SelectList(courses, "Id", "Name")
            };

            if (departments == null || courses == null)
            {
                return View("Error"); 
            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InstructorViewModel viewModel)
        {
            //string uniqueFileName = null;
            if (ModelState.IsValid)
            {
                if (viewModel.Image != null)
                {

                    IFormFile file = viewModel.Image as IFormFile;
                    string BinaryPath = Guid.NewGuid().ToString() + file.FileName;
                    string image = BinaryPath;

                    FileStream fs = new FileStream(
                      Path.Combine(Directory.GetCurrentDirectory(),
                      "wwwroot", "InstructorsImages", BinaryPath)
                      , FileMode.OpenOrCreate, FileAccess.ReadWrite);

                    file.CopyTo(fs);
                    fs.Position = 0;

                    var instructor = new Instractor
                    {
                        Name = viewModel.Name,
                        Image = image,
                        Address = viewModel.Address,
                        Salary = viewModel.Salary,
                        Dept_ID = viewModel.Dept_ID,
                        Crs_ID = viewModel.Crs_ID,
                    };
                    await repository.Create(instructor);
                }

                return RedirectToAction(nameof(Index));
            }
            
            viewModel.Departments = new SelectList(await departmentRepositroy.GetAll(), "Id", "Name");
            viewModel.Courses = new SelectList(await courseRepository.GetAll(), "Id", "Name");

            return View(viewModel);
        }
        


        public async Task <IActionResult> Update (int id) 
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructor = await repository.GetByID(id);
            if (instructor == null)
            {
                return NotFound();
            }

            var viewModel = new InstructorViewModel
            {
                Name = instructor.Name,
                Address = instructor.Address,
                Salary = instructor.Salary,
                Dept_ID = instructor.Dept_ID,
                Crs_ID = instructor.Crs_ID,
                Departments = new SelectList(await departmentRepositroy.GetAll(), "Id", "Name"),
                Courses = new SelectList(await courseRepository.GetAll(), "Id", "Name")
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, InstructorViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var instructor = await repository.GetByID(id);

                    if (viewModel.Image != null)
                    {
                        if (viewModel.Image.ContentType.ToLower() != "image/jpg" &&
                            viewModel.Image.ContentType.ToLower() != "image/jpeg")
                        {
                            ModelState.AddModelError("ImageFile", "The image must be a JPG or PNG or Jpeg file.");
                            viewModel.Departments = new SelectList
                                                        (await departmentRepositroy.GetAll(), "Id", "Name");
                            viewModel.Courses = new SelectList
                                                        (await courseRepository.GetAll(), "Id", "Name");
                            return View(viewModel);
                        }

                        IFormFile file = viewModel.Image as IFormFile;
                        string BinaryPath = Guid.NewGuid().ToString() + file.FileName;
                        string image = BinaryPath;

                        FileStream fs = new FileStream(
                          Path.Combine(Directory.GetCurrentDirectory(),
                          "wwwroot", "InstructorsImages", BinaryPath)
                          , FileMode.OpenOrCreate, FileAccess.ReadWrite);

                        file.CopyTo(fs);
                        fs.Position = 0;

                        instructor.Name = viewModel.Name;
                        instructor.Address = viewModel.Address;
                        instructor.Salary = viewModel.Salary;
                        instructor.Image = image;
                        instructor.Dept_ID = viewModel.Dept_ID;
                        instructor.Crs_ID = viewModel.Crs_ID;
                        await repository.Update(id, instructor);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IsExists(viewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return RedirectToAction("Index");

        }
        private bool IsExists(int id)
        {
            return (repository.IsExists(id));
        }
    }
}

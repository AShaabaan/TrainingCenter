using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using PresentationLayer.Models;
using PresentationLayer.Repository;
using System.Xml.Linq;

namespace PresentationLayer.Controllers
{
    public class TraineeController : Controller
    {
        Center context = new Center();
        private readonly ITraineeRepository repository;

        public TraineeController(ITraineeRepository _traineeRepository) 
        {
            this.repository = _traineeRepository;
        }
        public async Task <IActionResult >Index()
        {
            var Trainees = await repository.GetAll();
            return View(Trainees);
        }

        public async Task<IActionResult> Details(int id) 
        {
            var result = await repository.TrainesCrsResult(id); 
            

            List<TraineeViewModel> resultViewModels = new List<TraineeViewModel>();
            foreach (var item in result)
            {
                TraineeViewModel resultViewModel = new TraineeViewModel();
                resultViewModel.TraineeName = item.Trainee.Name;
                resultViewModel.Deparment = item.Trainee.Department.Name;
                resultViewModel.Courses.Add(item);
                if (item.Degree <= 55)
                {
                    resultViewModel.Color = "Red";
                    resultViewModel.State = "Failed";
                }
                else
                {
                    resultViewModel.Color = "Green";
                    resultViewModel.State = "Pass";
                }
                resultViewModels.Add(resultViewModel);
            }
            return View (resultViewModels);
        }

        public async Task<IActionResult> Update(int id)
        {
            Trainee trainee = await repository.GetByID(id);

            ViewBag.DeptList= context.Department.ToList();
            return View(trainee);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id , Trainee trainee)
        {
            Trainee OldStudent = await repository.GetByID(id);

            if (OldStudent != null)
            {
                //get old object
                OldStudent.Name = trainee.Name;
                OldStudent.Address = trainee.Address;
                OldStudent.Image = trainee.Image;
                OldStudent.Dept_ID = trainee.Dept_ID;
                await repository.Update(id, OldStudent);
            }
            return RedirectToAction("Index");
        }

        public async Task <ActionResult> Delete(int id)
        {
             await repository.Delete(id);
            return View();
        }

        
    }
}

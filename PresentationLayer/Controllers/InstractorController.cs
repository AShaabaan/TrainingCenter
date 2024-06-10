using Microsoft.AspNetCore.Mvc;
using Models;
using PresentationLayer.Repository;

namespace PresentationLayer.Controllers
{
    public class InstractorController : Controller
    {
        private readonly IInstractorRepository repository;

        public InstractorController(IInstractorRepository _repository)
        {
            repository = _repository;
        }
        public async Task <IActionResult> Index()
        {

            var Instractors = await repository.GetAll(); 
            return View(Instractors);
        }

        public async Task <IActionResult> Details(int id)
        {
            Instractor instractor = await repository.GetByID(id);
            return View(instractor);

        }
    }
}

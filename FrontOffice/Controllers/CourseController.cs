using System.Threading.Tasks;
using CommonLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Interfaces;

namespace FrontOffice.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.ErrorMessage = TempData["errorMessage"];
            return View(await _courseService.GetAll());
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(CourseViewModel model)
        {
            await _courseService.Add(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            return View(await _courseService.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CourseViewModel model)
        {
            var succes = await _courseService.Edit(model);
            TempData["errorMessage"] = succes
                ? ""
                : "Update operation was not successful completed. Check your inputs and try again.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _courseService.RemoveCourse(id);
            return RedirectToAction("Index");
        }
    }
}

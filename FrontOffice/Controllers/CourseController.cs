using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services;

namespace FrontOffice.Controllers
{
    public class CourseController : Controller
    {
        private readonly CourseService _courseService;

        public CourseController(CourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _courseService.GetCourses());
        }
    }
}

using System;
using System.Threading.Tasks;
using FrontOffice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceLayer.Interfaces;
using ServiceLayer.Services;

namespace FrontOffice.Controllers
{
    public class ExternalSourceController : Controller
    {
        private readonly ILogger<ExternalSourceController> _logger;
        private readonly IExternalProjectService _externalProjectService;

        public ExternalSourceController(ILogger<ExternalSourceController> logger, IExternalProjectService externalProjectService)
        {
            _logger = logger;
            this._externalProjectService = externalProjectService;
        }

        public IActionResult Index()
        {
            return View(new ResultViewModel());
        }

        public async Task<IActionResult> FetchStudents()
        {
            try
            {
                var result = await _externalProjectService.FetchStudents();
                return View("Index",new ResultViewModel
                {
                    IsFetched = true,
                    Message = $"Successfully fetched {result} students!"
                });
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
            return View("Index", new ResultViewModel());
        }

        public async Task<IActionResult> FetchTeachers()
        {
            try
            {
                var result = await _externalProjectService.FetchTeachers();
                return View("Index", new ResultViewModel
                {
                    IsFetched = true,
                    Message = $"Successfully fetched {result} teachers!"
                });
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
            return View("Index", new ResultViewModel());
        }

        public async Task<IActionResult> FetchCourses()
        {
            try
            {
                var result = await _externalProjectService.FetchCourses();

                return View("Index", new ResultViewModel
                {
                    IsFetched = true,
                    Message = $"Successfully fetched {result} courses!"
                });
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
            return View("Index", new ResultViewModel());
        }
    }
}

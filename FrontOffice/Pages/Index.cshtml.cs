using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataLayer.Entities;
using DataLayer.Repositories.Interfaces;

namespace FrontOffice.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IGenericRepository<Teacher> _teacherRepository;

        public IndexModel(ILogger<IndexModel> logger, IGenericRepository<Teacher> teacherRepository)
        {
            _logger = logger;
            _teacherRepository = teacherRepository;
        }

        public async Task OnGet()
        {
            await _teacherRepository.Add(new Teacher
            {
                Name = "Octavian-1",
                Surname = "Godonoga-1",
                Courses = new List<Course>()
            });
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Helpers;
using CommonLayer.ViewModels;

namespace ServiceLayer.Services
{
    public sealed class CourseService
    {
        private readonly CourseHelper _courseHelper;

        public CourseService(CourseHelper courseHelper)
        {
            _courseHelper = courseHelper;
        }

        public async Task<List<CourseViewModel>> GetCourses()
        {
            return await _courseHelper.GetAll();
        }
    }
}

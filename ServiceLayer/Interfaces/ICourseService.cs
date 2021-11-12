using System.Collections.Generic;
using System.Threading.Tasks;
using CommonLayer.ViewModels;

namespace ServiceLayer.Interfaces
{
    public interface ICourseService
    {
        Task<CourseViewModel> Get(int id);
        Task<List<CourseViewModel>> GetAll();
        Task Add(CourseViewModel model);
        Task<bool> Edit(CourseViewModel model);
        Task RemoveCourse(int id);
    }
}

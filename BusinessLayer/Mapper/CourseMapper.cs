using System.Collections.Generic;
using System.Linq;
using CommonLayer.ApiModels;
using CommonLayer.ViewModels;
using DataLayer.Entities;

namespace BusinessLayer.Mapper
{
    public static class CourseMapper
    {
        public static Course ToEntity(this CourseApi course)
        {
            return new Course
            {
                Name = course.Name,
                CreditsAmount = course.CreditsAmount,
                ClassRooms = new List<ClassRoom>()
            };
        }

        public static List<CourseViewModel> ToViewModel(this IList<Course> courses)
        {
            return courses.Select(x => new CourseViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Credits = x.CreditsAmount,
            }).ToList();
        }
    }
}

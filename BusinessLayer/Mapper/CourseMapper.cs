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
        public static Course ToEntity(this CourseViewModel course)
        {
            var entity = new Course
            {
                Name = course.Name,
                CreditsAmount = course.Credits,
                ClassRooms = new List<ClassRoom>()
            };
            if (course.Id > 0)
                entity.Id = course.Id;

            return entity;
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

        public static CourseViewModel ToViewModel(this Course courses)
        {
            return new CourseViewModel
            {
                Id = courses.Id,
                Name = courses.Name,
                Credits = courses.CreditsAmount,
            };
        }
    }
}

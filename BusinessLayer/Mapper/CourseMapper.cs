using System.Collections.Generic;
using CommonLayer.ApiModels;
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
    }
}

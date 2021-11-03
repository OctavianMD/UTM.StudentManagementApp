using System.Collections.Generic;
using CommonLayer.ApiModels;
using DataLayer.Entities;

namespace BusinessLayer.Mapper
{
    public static class TeacherMapper
    {
        public static Teacher ToEntity(this TeacherApi teacher)
        {
            return new Teacher
            {
                Name = teacher.Name,
                Surname = teacher.Surname,
                Courses = new List<Course>()
            };
        }
    }
}

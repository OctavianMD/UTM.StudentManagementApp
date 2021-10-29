using CommonLayer.ApiModels;
using DataLayer.Entities;

namespace BusinessLayer.Mapper
{
    public static class StudentMapper
    {
        public static Student ToEntity(this StudentApi student)
        {
            return new Student
            {
                Name = student.Name,
                Surname = student.Surname,
                Idnp = student.Idnp,
                BirthDate = student.BirthDate,
                EnrollmentDate = student.EnrollmentDate,
                ClassRoom = new ClassRoom()
            };
        }
    }
}

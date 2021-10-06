using System;

namespace DataLayer.Entities
{
    public class Student
    {
        public Guid Id { get; set; }
        public string Idnp { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public ClassRoom ClassRoom { get; set; }
    }
}

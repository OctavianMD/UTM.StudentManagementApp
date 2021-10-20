using System;

namespace CommonLayer.ApiModels
{
    public class StudentApi
    {
        public string Idnp { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}

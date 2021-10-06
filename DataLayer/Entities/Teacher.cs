using System.Collections.Generic;

namespace DataLayer.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public List<Course> Courses { get; set; }
    }
}

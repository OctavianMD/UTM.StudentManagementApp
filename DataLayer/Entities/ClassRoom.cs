using System.Collections.Generic;

namespace DataLayer.Entities
{
    public class ClassRoom
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Student> Students { get; set; }

        public List<Course> Courses { get; set; }
    }
}

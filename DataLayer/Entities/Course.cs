using System.Collections.Generic;

namespace DataLayer.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CreditsAmount { get; set; }

        public List<Student> Students { get; set; }
        public List<ClassRoom> ClassRooms { get; set; }

        public Teacher Teacher { get; set; }
    }
}

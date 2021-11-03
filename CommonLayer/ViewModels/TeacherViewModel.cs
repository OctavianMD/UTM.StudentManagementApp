using System.Collections.Generic;

namespace CommonLayer.ViewModels
{
    public class TeacherViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public List<CourseViewModel> Courses { get; set; }
    }
}

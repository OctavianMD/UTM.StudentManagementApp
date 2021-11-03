using System.Collections.Generic;

namespace CommonLayer.ViewModels
{
    public class ClassRoomViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<StudentViewModel> Students { get; set; }

        public List<CourseViewModel> Courses { get; set; }
    }
}

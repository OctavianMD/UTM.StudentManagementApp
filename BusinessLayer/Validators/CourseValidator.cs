using CommonLayer.ViewModels;

namespace BusinessLayer.Validators
{
    public static class CourseValidator
    {
        public static bool IsValid(this CourseViewModel course)
        {
            return !string.IsNullOrWhiteSpace(course.Name)
                   && course.Credits > 9
                   && course.Credits < 31;
        }
    }
}

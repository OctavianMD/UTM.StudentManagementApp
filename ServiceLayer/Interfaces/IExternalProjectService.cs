using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IExternalProjectService
    {
        Task<int> FetchStudents();
        Task<int> FetchTeachers();
        Task<int> FetchCourses();
    }
}

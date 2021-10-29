using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IExternalProjectHttpClient
    {
        Task<string> FetchStudents();
        Task<string> FetchTeachers();
        Task<string> FetchCourses();
    }
}

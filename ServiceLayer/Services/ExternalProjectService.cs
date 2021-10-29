using System.Threading.Tasks;
using ServiceLayer.Interfaces;

namespace ServiceLayer.Services
{
    public class ExternalProjectService: IExternalProjectService
    {
        private readonly IExternalProjectHttpClient _externalProjectHttpClient;

        public ExternalProjectService(IExternalProjectHttpClient externalProjectHttpClient)
        {
            _externalProjectHttpClient = externalProjectHttpClient;
        }

        public async Task<int> FetchStudents()
        {
            var result =  await _externalProjectHttpClient.FetchStudents();
            // ToDo implement logic
            return 0;
        }

        public async Task<int> FetchTeachers()
        {
            var result = await _externalProjectHttpClient.FetchTeachers();
            // ToDo implement logic
            return 0;
        }

        public async Task<int> FetchCourses()
        {
            var result = await _externalProjectHttpClient.FetchCourses();
            // ToDo implement logic
            return 0;
        }
    }
}

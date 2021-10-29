using System.Threading.Tasks;
using BusinessLayer.Helpers;
using ServiceLayer.Interfaces;

namespace ServiceLayer.Services
{
    public class ExternalProjectService: IExternalProjectService
    {
        private readonly IExternalProjectHttpClient _externalProjectHttpClient;
        private readonly StudentHelper _studentHelper;

        public ExternalProjectService(IExternalProjectHttpClient externalProjectHttpClient, StudentHelper studentHelper)
        {
            _externalProjectHttpClient = externalProjectHttpClient;
            _studentHelper = studentHelper;
        }

        public async Task<int> FetchStudents()
        {
            var result = await _externalProjectHttpClient.FetchStudents();
            return await _studentHelper.ProcessFetchedData(result);
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

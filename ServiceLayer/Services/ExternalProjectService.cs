using System.Threading.Tasks;
using BusinessLayer.Helpers;
using ServiceLayer.Interfaces;

namespace ServiceLayer.Services
{
    public class ExternalProjectService: IExternalProjectService
    {
        private readonly IExternalProjectHttpClient _externalProjectHttpClient;
        private readonly StudentHelper _studentHelper;
        private readonly TeacherHelper _teacherHelper;
        private readonly CourseHelper _courseHelper;

        public ExternalProjectService(
            IExternalProjectHttpClient externalProjectHttpClient,
            StudentHelper studentHelper,
            TeacherHelper teacherHelper, CourseHelper courseHelper)
        {
            _externalProjectHttpClient = externalProjectHttpClient;
            _studentHelper = studentHelper;
            _teacherHelper = teacherHelper;
            _courseHelper = courseHelper;
        }

        public async Task<int> FetchStudents()
        {
            var result = await _externalProjectHttpClient.FetchStudents();
            return await _studentHelper.ProcessFetchedData(result);
        }

        public async Task<int> FetchTeachers()
        {
            var result = await _externalProjectHttpClient.FetchTeachers();
            return await _teacherHelper.ProcessFetchedData(result);

        }

        public async Task<int> FetchCourses()
        {
            var result = await _externalProjectHttpClient.FetchCourses();
            return await _courseHelper.ProcessFetchedData(result);
        }
    }
}

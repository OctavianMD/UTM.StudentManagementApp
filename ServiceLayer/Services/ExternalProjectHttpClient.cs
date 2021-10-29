using System.Net.Http;
using System.Threading.Tasks;
using CommonLayer;
using ServiceLayer.Interfaces;

namespace ServiceLayer.Services
{
    public class ExternalProjectHttpClient: IExternalProjectHttpClient
    {
        private readonly HttpClient _httpClient;
        private const string StudentsEndpoint = "https://localhost:44354/api/university/students";
        private const string TeachersEndpoint = "https://localhost:44354/api/university/teachers";
        private const string CoursesEndpoint = "https://localhost:44354/api/university/courses";

        public ExternalProjectHttpClient(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient(Constants.ExternalHttpClientName);
        }


        public async Task<string> FetchStudents()
        {
            var response = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, StudentsEndpoint));
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> FetchTeachers()
        {
            var response = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, TeachersEndpoint));
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> FetchCourses()
        {
            var response = await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, CoursesEndpoint));
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}

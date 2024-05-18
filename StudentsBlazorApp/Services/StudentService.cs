using StudentsBlazorApp.Model;

namespace StudentsBlazorApp.Services
{
    public class StudentService
    {
        private readonly HttpClient _httpClient;

        public StudentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Student>>("https://localhost:7123/api/students");
        }

        public async Task<Student> GetStudentById(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<Student>($"https://localhost:7123/api/students/{id}");
        }

        public async Task AddStudent(Student student)
        {
            await _httpClient.PostAsJsonAsync("https://localhost:7123/api/students", student);
        }

        public async Task UpdateStudent(Guid id, Student student)
        {
            await _httpClient.PutAsJsonAsync($"https://localhost:7123/api/students/{id}", student);
        }

        public async Task DeleteStudent(Guid id)
        {
            await _httpClient.DeleteAsync($"https://localhost:7123/api/students/{id}");
        }
    }
}

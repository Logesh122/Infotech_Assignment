using StudentBlazorApp.Model;
using System.ComponentModel.DataAnnotations;

namespace StudentBlazorApp.Services
{
    public class StudentService
    {
        private readonly HttpClient _httpClient;

        public StudentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Students>> GetStudentsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Students>>("api/Students/GetStudents");
        }

        public async Task<Students> GetStudentByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<Students>($"api/Students/GetStudentsById/{id}");
        }
        public async Task AddStudentAsync(Students student)
        {
            await _httpClient.PostAsJsonAsync("api/Students/AddStudentDetails", student);
        }

        public async Task UpdateStudentAsync(Students student)
        {
            await _httpClient.PutAsJsonAsync($"api/Students/UpdateStudentDetails/{student.Id}", student);
        }

        public async Task DeleteStudentAsync(Guid id)
        {
            await _httpClient.DeleteAsync($"api/Students/DeleteStudentDetails/{id}");
        }

    }

}

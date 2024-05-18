using StudentsDetail.Models;

namespace StudentsDetail.Repository
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Students>> GetStudents();
        Task<Students?> GetStudentById(Guid id);
        Task<Students> AddStudent(Students student);
        Task<Students?> UpdateStudent(Guid id, UpdateStudents student);
        Task<Students?> DeleteStudent(Guid id);
    }
}

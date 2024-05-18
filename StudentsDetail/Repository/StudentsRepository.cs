using Microsoft.EntityFrameworkCore;
using StudentsDetail.Data;
using StudentsDetail.Models;

namespace StudentsDetail.Repository
{
    public class StudentsRepository:IStudentRepository
    {


        private readonly StudentDetailsDbContext dbContext;

        public StudentsRepository(StudentDetailsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<Students>> GetStudents()
        {
            return await dbContext.Students.ToListAsync();
        } 

        public async Task<Students?> GetStudentById(Guid id)
        {
            return await dbContext.Students.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Students> AddStudent(Students student)
        {

            student.Id = Guid.NewGuid();
            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();
            return student;
        }

        public async Task<Students?> UpdateStudent(Guid id, UpdateStudents student)
        {
           
            var existingStudents=await dbContext.Students.FirstOrDefaultAsync(x=> x.Id == id);
            if (existingStudents == null)
            {
                return null;
            }
            existingStudents.Name=student.Name;
            existingStudents.Email=student.Email;
            existingStudents.Address = student.Address;
            existingStudents.Email = student.Email;
            existingStudents.PhoneNumber = student.PhoneNumber;

            await dbContext.SaveChangesAsync();
            return existingStudents;
          
        }

        public async Task<Students?> DeleteStudent(Guid id)
        {
            var student = await dbContext.Students.FindAsync(id);
            if(student == null)
            {
                return null;
            }
            
                dbContext.Students.Remove(student);
                await dbContext.SaveChangesAsync();
                return student;
            
        }



    }
}

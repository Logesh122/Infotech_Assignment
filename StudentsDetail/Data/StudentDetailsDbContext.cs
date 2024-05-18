using Microsoft.EntityFrameworkCore;
using StudentsDetail.Models;
using System.Runtime.CompilerServices;

namespace StudentsDetail.Data
{
    public class StudentDetailsDbContext : DbContext
    {
        public StudentDetailsDbContext(DbContextOptions<StudentDetailsDbContext> options): base(options) 
        {

        }
       public DbSet<Students>Students { get; set; }
    }
}

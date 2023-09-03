using Microsoft.EntityFrameworkCore;
using School.Domain.Entities;
using School.Domain.Repositories;
using School.Infrastructure.Database;

namespace School.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolDbContext dbContext;

        public StudentRepository(SchoolDbContext schoolDbContext)
        {
            this.dbContext = schoolDbContext;
        }

        public void AddStudent(Student student) => dbContext.Students.Add(student);

        public void UpdateStudent(Student student) => dbContext.Update(student);

        public void DeleteStudent(Student student) => dbContext.Students.Remove(student);

        public async Task<Student> GetStudentById(int id) =>
            await dbContext.Students.FirstOrDefaultAsync(student => student.StudentId == id);

        public async Task<List<Student>> GetStudents() => await dbContext.Students.Include(student => student.Grades).ToListAsync();

        public async Task<bool> SaveChanges() => await dbContext.SaveChangesAsync() >= 0;

        public async Task<bool> StudentExists(int id) => await dbContext.Students.AnyAsync(student => student.StudentId == id);

    }
}

using Microsoft.EntityFrameworkCore;
using School.Domain.Entities;
using School.Domain.Repositories;
using School.Infrastructure.Database;

namespace School.Infrastructure.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        private readonly SchoolDbContext dbContext;

        public GradeRepository(SchoolDbContext schoolDbContext)
        {
            dbContext = schoolDbContext;
        }

        public async Task<List<Grade>> GetStudentGrades(int studentId) =>
           await dbContext.Grades.Where(grade => grade.Student.StudentId == studentId).ToListAsync();

        public async Task CreateGrade(int studentId, Grade grade)
        {
            var student = await dbContext.Students.FirstOrDefaultAsync();
            grade.Student = student;
            dbContext.Grades.Add(grade);
        }

        public void DeleteGrade(Grade grade) => dbContext.Grades.Remove(grade);

        public void UpdateGrade(Grade grade) => dbContext.Update(grade);

        public async Task<bool> SaveChanges() => await dbContext.SaveChangesAsync() >= 0;

        public async Task<bool> GradeExists(int gradeId) =>
            await dbContext.Grades.AnyAsync(grade => grade.GradeId == gradeId);

        public async Task<Grade> GetGrade(int id) =>
            await dbContext.Grades.FirstOrDefaultAsync(grade => grade.GradeId.Equals(id));
    }
}

using Microsoft.EntityFrameworkCore;
using School.Domain.Entities;
using School.Domain.Repositories;
using School.Infrastructure.Database;

namespace School.Infrastructure.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly SchoolDbContext dbContext;

        public TeacherRepository(SchoolDbContext schoolDbContext)
        {
            dbContext = schoolDbContext;
        }

        public void AddTeacher(Teacher teacher) => dbContext.Teachers.Add(teacher);

        public void UpdateTeacher(Teacher teacher) => dbContext.Update(teacher);

        public void DeleteTeacher(Teacher teacher) => dbContext.Teachers.Remove(teacher);

        public async Task<Teacher> GetTeacher(int id) =>
            await dbContext.Teachers.FirstOrDefaultAsync(teacher => teacher.TeacherId == id);

        public async Task<List<Teacher>> GetTeachers() => await dbContext.Teachers.ToListAsync();

        public async Task<bool> TeacherExists(int id) => await dbContext.Teachers.AnyAsync(teacher => teacher.TeacherId == id);

        public async Task<bool> SaveChanges() => await dbContext.SaveChangesAsync() >= 0;
    }
}

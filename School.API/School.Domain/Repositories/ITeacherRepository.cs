using School.Domain.Entities;

namespace School.Domain.Repositories
{
    public interface ITeacherRepository
    {
        Task<List<Teacher>> GetTeachers();

        Task<Teacher> GetTeacher(int id);

        void AddTeacher(Teacher teacher);

        void UpdateTeacher(Teacher teacher);

        void DeleteTeacher(Teacher teacher);

        Task<bool> TeacherExists(int id);

       Task<bool> SaveChanges();
    }
}

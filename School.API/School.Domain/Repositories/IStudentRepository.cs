using School.Domain.Entities;

namespace School.Domain.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudents();

        Task<Student> GetStudent(int id);

        Task AddStudent(Student student);

        Task DeleteStudent(int id);
    }
}

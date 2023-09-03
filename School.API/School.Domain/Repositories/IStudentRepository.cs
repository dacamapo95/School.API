using School.Domain.Entities;

namespace School.Domain.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudents();

        Task<Student> GetStudentById(int id);

        void AddStudent(Student student);

        void UpdateStudent(Student student);

        void DeleteStudent(Student student);

        Task<bool> StudentExists(int id);

        Task<bool> SaveChanges();


    }
}

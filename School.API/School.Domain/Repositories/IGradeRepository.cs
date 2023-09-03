using School.Domain.Entities;

namespace School.Domain.Repositories
{
    public interface IGradeRepository
    {
        Task<List<Grade>> GetStudentGrades(int studentId);
        Task<Grade> GetGrade(int id);
        Task CreateGrade(int studentId, Grade grade);
        void UpdateGrade(Grade grade);
        void DeleteGrade(Grade grade);
        Task<bool> GradeExists(int gradeId);
        Task<bool> SaveChanges();
    }
}

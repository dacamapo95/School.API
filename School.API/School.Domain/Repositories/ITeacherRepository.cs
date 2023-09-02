using School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Repositories
{
    internal interface ITeacherRepository
    {
        Task<List<Teacher>> GetTeachers();

        Task<Teacher> GetTeacher(int id);

        Task AddTeacher(Teacher teacher);  

        Task UpdateTeacher(Teacher teacher);

        Task DeleteTeacher(int id);
    }
}

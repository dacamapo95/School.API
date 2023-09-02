using School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Domain.Repositories
{
    public interface ICourseRepository
    {
        Task AddCourse(Course course);

        Task UpdateCourse(Course course);

        Task DeleteCourse(Course course);
    }
}

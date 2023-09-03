using Microsoft.EntityFrameworkCore;
using School.Domain.Entities;

namespace School.Infrastructure.Database
{
    public class SchoolDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }    

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Grade> Grades { get; set; }    

        public DbSet<Course> Courses { get; set; }

        public SchoolDbContext(DbContextOptions<SchoolDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Student>()
                .HasMany(student => student.Grades)
                .WithOne(grade => grade.Student)
                .HasForeignKey(grade => grade.StudentId);

            //modelBuilder
            //    .Entity<Teacher>()
            //    .HasMany(student => student.Courses)
            //    .WithOne(course => course.Teacher)
            //    .HasForeignKey(course => course.Teacher);

            base.OnModelCreating(modelBuilder);
        }
    }
}

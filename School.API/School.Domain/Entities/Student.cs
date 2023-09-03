namespace School.Domain.Entities
{
    public class Student
    {
        public int StudentId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public List<Grade> Grades { get; set; }
    }
}

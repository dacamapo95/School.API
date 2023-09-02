namespace School.Domain.Entities
{ 
    public class Grade
    {
        public int GradeId { get; set; }

        public string Assigment { get; set; }

        public double GradeValue { get; set; }

        public virtual Student Student { get; set; }
    }
}

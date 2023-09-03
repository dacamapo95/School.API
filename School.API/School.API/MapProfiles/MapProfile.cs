namespace School.API.MapProfiles
{
    using AutoMapper;
    using School.Domain.Entities;
    using School.Infrastructure.DataTransferObjects;

    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Student, StudentDTO>()
                .ForMember(student => student.Grades, options => options.MapFrom(MapGradesFromStudent));
            CreateMap<StudentDTO, Student>();
            CreateMap<Teacher, TeacherDTO>();
            CreateMap<TeacherDTO, Teacher>();
            CreateMap<Grade, GradeDTO>();
            CreateMap<GradeDTO, Grade>();
        }

        private List<GradeDTO> MapGradesFromStudent(Student student, StudentDTO studentDTO)
        {
            if (student.Grades is null) return new List<GradeDTO>();
            
            return
            student
                .Grades
                .Select(grade => new GradeDTO
                {
                    Assigment = grade.Assigment,
                    GradeValue = grade.GradeValue
                }).ToList();
        }
    }
}

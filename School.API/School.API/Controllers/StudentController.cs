using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using School.Domain.Entities;
using School.Domain.Repositories;
using School.Infrastructure.DataTransferObjects;

namespace School.API.Controllers
{

    [ApiController]
    [Route("api/students")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentController(IStudentRepository studentRepository,
                                 IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _studentRepository.GetStudents();

            return Ok(_mapper.Map<List<StudentDTO>>(students));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var student = await _studentRepository.GetStudentById(id);
            if (student == null) return NotFound();

            return Ok(_mapper.Map<StudentDTO>(student));
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] StudentDTO student)
        {
            if (student == null) return BadRequest();

            _studentRepository.AddStudent(_mapper.Map<Student>(student));

            await _studentRepository.SaveChanges();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] StudentDTO studentDTO)
        {
            if (studentDTO == null) return BadRequest();

            if (!await _studentRepository.StudentExists(id)) return NotFound();

            var studentToUpdate = _mapper.Map<Student>(studentDTO);
            studentToUpdate.StudentId = id;

            _studentRepository.UpdateStudent(studentToUpdate);

            await _studentRepository.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var StudentToDelete = await _studentRepository.GetStudentById(id);

            if (StudentToDelete == null) return NotFound();

            _studentRepository.DeleteStudent(StudentToDelete);

            await _studentRepository.SaveChanges();

            return Ok();
        }
    }
}

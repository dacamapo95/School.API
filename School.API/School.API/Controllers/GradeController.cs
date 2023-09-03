using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using School.Domain.Entities;
using School.Domain.Repositories;
using School.Infrastructure.DataTransferObjects;
using School.Infrastructure.Repositories;

namespace School.API.Controllers
{
    [Route("api/grades")]
    public class GradeController : Controller
    {
        private readonly IGradeRepository _gradeRepository;
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;

        public GradeController(IGradeRepository gradeRepository,
                               IStudentRepository studentRepository,
                               IMapper mapper)
        {
            _gradeRepository = gradeRepository;
            _mapper = mapper;
            _studentRepository = studentRepository;
        }


        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetGrades(int studentId)
            => Ok(_mapper.Map<List<GradeDTO>>(await _gradeRepository.GetStudentGrades(studentId)));


        [HttpPost("{id}")]
        public async Task<IActionResult> CreateGrade(int id, [FromBody] GradeDTO grade)
        {
            if (grade == null) return BadRequest();

            if (!await _studentRepository.StudentExists(id)) return NotFound($"No se encontró estudiante con Id:{id}");

            await _gradeRepository.CreateGrade(id, _mapper.Map<Grade>(grade));

            await _gradeRepository.SaveChanges();

            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrade(int id, [FromBody] GradeDTO grade)
        {
            if (grade == null) return BadRequest();

            if (!await _gradeRepository.GradeExists(id)) return NotFound();

            var GradeToDelete = await _gradeRepository.GetGrade(id);

            _gradeRepository.DeleteGrade(GradeToDelete);

            await _gradeRepository.SaveChanges();

            return Ok();
        }

    }
}

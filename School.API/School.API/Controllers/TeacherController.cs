using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using School.Domain.Entities;
using School.Domain.Repositories;
using School.Infrastructure.DataTransferObjects;

namespace School.API.Controllers
{
    [Route("api/teachers")]
    public class TeacherController : Controller
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;

        public TeacherController(ITeacherRepository teacherRepository,
                                 IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTeachers()
        {
            var teachers = await _teacherRepository.GetTeachers();

            return Ok(_mapper.Map<List<TeacherDTO>>(teachers));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeacher(int id)
        {
            var teacher = await _teacherRepository.GetTeacher(id);
            if (teacher == null) return NotFound();
            return Ok(_mapper.Map<TeacherDTO>(teacher));
        }

        [HttpPost]
        public async Task<IActionResult> CreateTeacher([FromBody] TeacherDTO teacher)
        {
            if (teacher == null) return BadRequest();

            _teacherRepository.AddTeacher(_mapper.Map<Teacher>(teacher));

            await _teacherRepository.SaveChanges();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTeacher(int id, [FromBody] TeacherDTO teacher)
        {
            if (teacher == null) return BadRequest();

            if (! await _teacherRepository.TeacherExists(id)) return NotFound();

            var teacherToUpdate = _mapper.Map<Teacher>(teacher);
            teacherToUpdate.TeacherId = id;

            _teacherRepository.UpdateTeacher(teacherToUpdate);

            await _teacherRepository.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var teacherToDelete = await _teacherRepository.GetTeacher(id);

            if (teacherToDelete == null) return NotFound();

            _teacherRepository.DeleteTeacher(teacherToDelete);

            await _teacherRepository.SaveChanges();

            return Ok();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using StudentsApi.Models;
using StudentsApi.Services;

namespace StudentsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentsController(IStudentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _service.GetAllAsync();
            return Ok(students);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetStudent(Guid id)
        {
            var student = await _service.GetByIdAsync(id);
            if (student == null) return NotFound();
            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] StudentDto dto)
        {
            var result = await _service.AddAsync(dto.Name, dto.Surname);
            return StatusCode(201, result);
        }

        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> PatchStudent(Guid id, [FromBody] StudentUpdateDto dto)
        {
            var result = await _service.UpdateAsync(id, dto.Name, dto.Surname);
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            var ok = await _service.DeleteAsync(id);
            if (!ok) return NotFound();
            return Ok();
        }
    }
}

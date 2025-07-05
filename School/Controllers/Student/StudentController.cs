using Microsoft.AspNetCore.Mvc;
using School.Models;
using School.Services.Student;

namespace School.Controllers.Student;

[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly IStudentService _context;

    public StudentController(IStudentService context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetAllStudents()
    {
        return Ok(_context.GetAllStudents());
    }

    [HttpGet("{id}")]
    public IActionResult GetStudentById(Guid id)
    {
        var student = _context.GetStudentById(id);
        return Ok(student);
    }

    [HttpPost("CreateStudent")]
    public IActionResult CreateStudent([FromBody] StudentModel student)
    {
        _context.AddStudent(student);
        return Ok("Success, student added!");
    }

    [HttpPut("{studentId}")]
    public IActionResult UpdateStudent([FromRoute] Guid studentId, [FromBody] StudentModel student)
    {
        var upStudent = _context.UpdateStudent(studentId ,student);
        if (upStudent == null)
        {
            return NotFound("Student not found!");
        }
        return Ok("Success, student updated!");
    }

    [HttpDelete("DeleteStudent")]
    public IActionResult DeleteStudent(Guid id)
    {
        _context.DeleteStudent(id);
        return Ok("Success, student deleted!");
    }
}
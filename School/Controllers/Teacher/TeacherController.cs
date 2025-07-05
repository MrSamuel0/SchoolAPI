using Microsoft.AspNetCore.Mvc;
using School.Models;
using School.Services.Teacher;

namespace School.Controllers.Teacher;

[ApiController]
[Route("api/[controller]")]
public class TeacherController : ControllerBase
{
    private readonly ITeacherService _context;

    public TeacherController(ITeacherService context)
    {
        _context = context;
    }
    
    [HttpGet]
    public IActionResult GetTeacherAllTeachers()
    {
        return Ok(_context.GetTeachers());
    }

    [HttpGet("{id}")]
    public IActionResult GetTeacherById(Guid id)
    {
        var teacher = _context.GetTeacherById(id);
        if (teacher == null)
        {
            return NotFound("Teacher not found!");
        }
        return Ok(teacher);
    }

    [HttpPost("AddTeacher")]
    public IActionResult AddTeacher([FromBody] TeacherModel newTeacher)
    {
        _context.AddTeacher(newTeacher);
        return Ok("Success, teacher added!");
    }

    [HttpPut("{teacherId}")]
    public IActionResult UpdateTeacher([FromRoute] Guid teacherId, [FromBody] TeacherModel updatedTeacher)
    {
        var upTeacher = _context.UpdateTeacher(teacherId, updatedTeacher);
        if (upTeacher == null)
        {
            return NotFound("Teacher not found!");
        }
        return Ok("Success, teacher updated!");
    }

    [HttpDelete("DeleteTeacher")]
    public IActionResult DeleteTeacher(Guid teacherId)
    {
        _context.DeleteTeacher(teacherId);
        return Ok("Success, teacher deleted!");
    }
}
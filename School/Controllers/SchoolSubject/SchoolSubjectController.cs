using Microsoft.AspNetCore.Mvc;
using School.Models;
using School.Services.SchoolSubject;

namespace School.Controllers.SchoolSubject;

[ApiController]
[Route("[controller]")]
public class SchoolSubjectController : ControllerBase
{
    private readonly ISchoolSubjectService _context;

    public SchoolSubjectController(ISchoolSubjectService context)
    {
        _context = context;
    }

    [HttpPost("AddSchoolSubject")]
    public IActionResult AddSchoolSubject(SchoolSubjectsModel schoolSubjects)
    {
        _context.CreateNewSchoolSubject(schoolSubjects);
        return Ok("Success, school subject added!");
    }
}
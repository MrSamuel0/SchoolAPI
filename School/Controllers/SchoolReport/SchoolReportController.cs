using Microsoft.AspNetCore.Mvc;
using School.Models;
using School.Services.SchoolReport;

namespace School.Controllers.SchoolReport;

[ApiController]
[Route("[controller]")]
public class SchoolReportController : ControllerBase
{
    private readonly ISchoolReportService _context;

    public SchoolReportController(ISchoolReportService context)
    {
        _context = context;
    }

    [HttpGet("GetSchoolReport")]
    public IActionResult GetSchoolReport(Guid studentId)
    {
        var schoolReport = _context.GetStudentSchoolReport(studentId);
        if (schoolReport == null)
        {
            return NotFound("School Report not found!");
        }
        return Ok();
    }

    [HttpPost("AddSchoolReport")]
    public IActionResult AddSchoolReport(SchoolReportModel schoolReport)
    {
        _context.CreateNewSchoolReport(schoolReport);
        return Ok("Success, school report added!");
    }
    
}
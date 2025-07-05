using School.Data;
using School.Models;

namespace School.Services.SchoolReport;

public class SchoolReportService : ISchoolReportService
{
    private readonly SchoolDbContext _context;

    public SchoolReportService(SchoolDbContext context)
    {
        _context = context;
    }

    public void CreateNewSchoolReport(SchoolReportModel schoolReport)
    {
        while (_context.SchoolReport.Any(s => s.Id == schoolReport.Id))
        {
            schoolReport.ReGenId();
        }
        _context.SchoolReport.Add(schoolReport);
        _context.SaveChanges();
    }
    
    public SchoolReportModel? GetStudentSchoolReport(Guid studentId)
    {
        return _context.SchoolReport.Find(studentId);
    }
}
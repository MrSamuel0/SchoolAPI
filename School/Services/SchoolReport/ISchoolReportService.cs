using School.Models;

namespace School.Services.SchoolReport;

public interface ISchoolReportService
{
    void CreateNewSchoolReport(SchoolReportModel schoolReport);
    SchoolReportModel? GetStudentSchoolReport(Guid studentId);
}
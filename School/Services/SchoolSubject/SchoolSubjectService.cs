using School.Data;
using School.Models;

namespace School.Services.SchoolSubject;

public class SchoolSubjectService : ISchoolSubjectService
{
    private readonly SchoolDbContext _context;

    public SchoolSubjectService(SchoolDbContext context)
    {
        _context = context;
    }
    
    public void CreateNewSchoolSubject(SchoolSubjectsModel schoolSubjects)
    {
        while (_context.SchoolSubjects.Any(s => s.Id == schoolSubjects.Id))
        {
            schoolSubjects.ReGenId();
        }
        _context.Add(schoolSubjects);
        _context.SaveChanges();
    }
}
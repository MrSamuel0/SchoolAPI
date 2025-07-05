using School.Data;
using School.Models;

namespace School.Services.Teacher;

public class TeacherService : ITeacherService
{
    private readonly SchoolDbContext _context;

    public TeacherService(SchoolDbContext context)
    {
        _context = context;
    }

    public void AddTeacher(TeacherModel newTeacher)
    {
        while (_context.Teachers.Any(t => t.Id == newTeacher.Id))
        {
            newTeacher.ReGenId();
        }
        _context.Teachers.Add(newTeacher);
        _context.SaveChanges();
    }

    public void DeleteTeacher(Guid teacherId)
    {
        var teacher = _context.Teachers.Find(teacherId);
        if (teacher != null)
        {
            _context.Teachers.Remove(teacher);
        }
        _context.SaveChanges();
    }

    public TeacherModel? UpdateTeacher(Guid teacherId, TeacherModel updatedTeacher)
    {
        var teacher = _context.Teachers.Find(teacherId);
        if (teacher == null)
        {
            return null;
        }
        teacher.Name = updatedTeacher.Name;
        teacher.Email = updatedTeacher.Email;
        _context.SaveChanges();
        return teacher; 
    }

    public TeacherModel? GetTeacherById(Guid teacherId)
    {
        return _context.Teachers.Find(teacherId);
    }

    public List<TeacherModel> GetTeachers()
    {
        return _context.Teachers.ToList();
    }
}
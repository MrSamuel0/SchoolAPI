using School.Data;
using School.Models;

namespace School.Services.Student;

public class StudentService : IStudentService
{
    private readonly SchoolDbContext _context;
    
    public StudentService(SchoolDbContext context)
    {
        _context = context;
    }

    public void AddStudent(StudentModel newStudent)
    {
        while (_context.Students.Any(s => s.Name == newStudent.Name))
        {
            newStudent.ReGenId();
        }   
        _context.Students.Add(newStudent);
        _context.SaveChanges();
    }

    public StudentModel? UpdateStudent(Guid studentId, StudentModel updatedStudent)
    {
        var student = _context.Students.Find(studentId);
        if (student == null)
        {
            return null;
        }
        student.Name = updatedStudent.Name;
        student.Email = updatedStudent.Email;
        _context.SaveChanges();
        return student;
    }

    public void DeleteStudent(Guid studentId)
    {
        var student = _context.Students.Find(studentId);
        if (student != null)
        {
            _context.Students.Remove(student);    
        }
        _context.SaveChanges();
    }

    public StudentModel? GetStudentById(Guid studentId)
    {
        return _context.Students.Find(studentId);
    }

    public List<StudentModel> GetAllStudents()
    {
        return _context.Students.ToList();
    }
}
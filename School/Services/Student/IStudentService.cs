using School.Models;

namespace School.Services.Student;

public interface IStudentService
{
    void AddStudent(StudentModel newStudent);

    StudentModel? UpdateStudent(Guid studentId, StudentModel updatedStudent);

    void DeleteStudent(Guid studentId);

    StudentModel? GetStudentById(Guid studentId);
    
    List<StudentModel> GetAllStudents();
}
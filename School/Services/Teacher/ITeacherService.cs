using School.Models;

namespace School.Services.Teacher;

public interface ITeacherService
{
    void AddTeacher(TeacherModel newTeacher);

    void DeleteTeacher(Guid teacherId);

    TeacherModel? UpdateTeacher(Guid teacherId, TeacherModel updatedTeacher);

    TeacherModel? GetTeacherById(Guid teacherId);

    List<TeacherModel> GetTeachers();
}
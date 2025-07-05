using Microsoft.EntityFrameworkCore;
using School.Models;

namespace School.Data;

public class SchoolDbContext : DbContext
{
    
    public DbSet<SchoolReportModel> SchoolReport { get; set; }
    public DbSet<SchoolSubjectsModel> SchoolSubjects { get; set; }
    public DbSet<StudentModel> Students { get; set; }
    public DbSet<TeacherModel> Teachers { get; set; }
    
    public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options) {}
}
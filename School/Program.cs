using School.Data;
using School.Services.SchoolReport;
using School.Services.SchoolSubject;
using School.Services.Student;
using School.Services.Teacher;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<SchoolDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<ISchoolReportService, SchoolReportService>();
builder.Services.AddScoped<ISchoolSubjectService, SchoolSubjectService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();


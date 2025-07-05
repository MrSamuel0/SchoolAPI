namespace School.Models;

public class SchoolReportModel : IIdReGen
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string? SchoolName { get; set; }
    public string? SchoolYear { get; set; }
    public string? SchoolClass { get; set; }
    public Guid SubjectsId { get; set; }
    public Guid StudentId { get; set; }

    public void ReGenId()
    {
        this.Id = Guid.NewGuid();
    }
}
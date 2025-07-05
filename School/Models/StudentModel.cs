namespace School.Models;

public class StudentModel : IIdReGen
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public Guid Id { get; private set; } = Guid.NewGuid();
    
    public void ReGenId()
    {
        this.Id = Guid.NewGuid();
    }
}
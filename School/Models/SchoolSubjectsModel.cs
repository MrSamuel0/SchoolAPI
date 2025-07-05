namespace School.Models;

public class SchoolSubjectsModel : IIdReGen
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public decimal Math { get; set; }
    public decimal Portuguese { get; set; }
    public decimal English { get; set; }
    public decimal Chemistry { get; set; }
    public decimal Physics { get; set; }
    public decimal Biology { get; set; }
    public decimal Geography { get; set; }
    public decimal History { get; set; }
    
    public void ReGenId()
    {
        this.Id = Guid.NewGuid();
    }
}
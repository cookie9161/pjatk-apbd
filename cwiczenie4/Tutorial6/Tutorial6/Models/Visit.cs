namespace Tutorial6.Models;

public class Visit
{
    public required DateTime VisitDate { get; set; }
    public required string Description { get; set; }
    public required string VisitPrice { get; set; }
    public required Animal Animal { get; set; }
}
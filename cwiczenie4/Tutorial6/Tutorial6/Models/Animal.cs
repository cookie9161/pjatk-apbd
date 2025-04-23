namespace Tutorial6.Models;

public class Animal
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public required Category Category { get; set; }
    public required double Mass { get; set; }
    public required FurrColor FurrColor { get; set; }
}
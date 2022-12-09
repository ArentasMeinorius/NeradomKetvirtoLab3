namespace NeradomKetvirtoLab3.Models;

public class Procedure
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string EstimatedDuration { get; set; }
}
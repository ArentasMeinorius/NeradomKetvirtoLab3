namespace NeradomKetvirtoLab3.Models;

public class Consumable
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public Recipe[] Recipe { get; set; }
    public decimal Price { get; set; }
}
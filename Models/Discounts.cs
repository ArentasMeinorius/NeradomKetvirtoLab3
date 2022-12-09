namespace NeradomKetvirtoLab3.Models;

public class Discounts
{
    public Guid Id { get; set; }
    public Consumable Item { get; set; }
    public int Percentage { get; set; }
    public Guid Conditions { get; set; }
}
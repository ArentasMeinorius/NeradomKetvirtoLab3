namespace NeradomKetvirtoLab3.Models;

public class Ingredient
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public decimal Units { get; set; }
    public Measurement Measurement { get; set; }
}

public enum Measurement
{
    Gram,
    Milliliter
}
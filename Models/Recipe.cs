namespace NeradomKetvirtoLab3.Models;

public class Recipe
{
    public Guid Id { get; set; }
    public ICollection<Ingredient> IngredientId { get; set; }
}
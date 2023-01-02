using Microsoft.EntityFrameworkCore;
using NeradomKetvirtoLab3.Database;
using NeradomKetvirtoLab3.Models;

namespace NeradomKetvirtoLab3.Repositories;

public class ConsumablesRepository : IConsumablesRepository
{
    public ConsumablesRepository()
    {
        using var context = new ProjectDbContext();
        
        var consumables = new List<Consumable>
        {
            new Consumable
            {
                Id = Guid.NewGuid(),
                Title = "Chocolate Cake",
                Description = "A delicious chocolate cake with a rich, fudgy texture.",
                Recipe = new Recipe[]
                {
                    new Recipe
                    {
                        Id = Guid.NewGuid(),
                        IngredientId = new Ingredient[]
                        {
                            new Ingredient
                            {
                                Id = Guid.NewGuid(),
                                Title = "Flour",
                                Units = 250,
                                Measurement = Measurement.Gram
                            },
                            new Ingredient
                            {
                                Id = Guid.NewGuid(),
                                Title = "Sugar",
                                Units = 200,
                                Measurement = Measurement.Gram
                            },
                            new Ingredient
                            {
                                Id = Guid.NewGuid(),
                                Title = "Chocolate",
                                Units = 150,
                                Measurement = Measurement.Gram
                            }
                        }
                    }
                },
                Price = 15
            }
        };
        
        context.Consumables.AddRange(consumables);
        context.SaveChanges();
    }

    public async Task<Consumable?> Update(Consumable newConsumable)
    {
        using var context = new ProjectDbContext();
        var consumable = await context.Consumables.FirstOrDefaultAsync(consumable => consumable.Id.Equals(newConsumable.Id));
        if (consumable == null)
        {
            return null;
        }
        consumable.Title = newConsumable.Title;
        consumable.Description = newConsumable.Description;
        consumable.Recipe = newConsumable.Recipe;
        consumable.Price = newConsumable.Price;
        context.Consumables.Update(consumable);
        await context.SaveChangesAsync();
        return consumable;
    }

    public async Task<IEnumerable<Consumable>> GetAll()
    {
        await using var context = new ProjectDbContext();
        return await context.Consumables.ToListAsync();
    }
}
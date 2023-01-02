using Microsoft.EntityFrameworkCore;
using NeradomKetvirtoLab3.Database;
using NeradomKetvirtoLab3.Models;

namespace NeradomKetvirtoLab3.Repositories;

public class VisitsRepository : IVisitsRepository
{
    public VisitsRepository()
    {
        using var context = new ProjectDbContext();
        
        var visits = new List<Visit>
            {
                new Visit
                {
                    Id = Guid.NewGuid(),
                    TableId = new Table
                    {
                        Id = Guid.NewGuid(),
                        SeatCount = 4,
                        IsOccupied = true
                    },
                    Reservant = new Reservant
                    {
                        Id = Guid.NewGuid(),
                        Name = "John Smith",
                        PhoneNumber = "+37000000000"
                    },
                    GuestCount = 4,
                    StartDateTime = DateTime.Now,
                    EndDateTime = DateTime.Now.AddHours(2),
                    Orders = new Order[]
                    {
                        new Order
                        {
                            Id = Guid.NewGuid(),
                            OrderStatus = OrderStatus.Completed,
                            Comment = "Extra sauce on the side, please.",
                            OrderItems = new Consumable[]
                            {
                                new Consumable
                                {
                                    Id = Guid.NewGuid(),
                                    Title = "Pizza",
                                    Description = "Delicious pizza.",
                                    Price = 20,
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
                                                    Title = "Yeast",
                                                    Units = 7,
                                                    Measurement = Measurement.Gram
                                                },
                                                new Ingredient
                                                {
                                                    Id = Guid.NewGuid(),
                                                    Title = "Mozzarella",
                                                    Units = 250,
                                                    Measurement = Measurement.Gram
                                                }
                                            }
                                        }
                                    }
                                },
                                new Consumable
                                {
                                    Id = Guid.NewGuid(),
                                    Description = "Refreshing soda",
                                    Title = "Soda",
                                    Price = 5
                                }
                            },
                            EstimatedDeliveryTime = DateTime.Now.AddMinutes(30),
                            PaymentMethod = PaymentMethod.Card,
                            Paid = 25
                        }
                    }
                }
            };
        
        context.Visits.AddRange(visits);
        context.SaveChanges();
    }

    public async Task<Visit?> AddVisit(Visit newVisit)
    {
        await using var context = new ProjectDbContext();
        await context.Visits.AddAsync(newVisit);
        await context.SaveChangesAsync();
        return newVisit;
    }

    public async Task<Visit?> GetVisit(Guid visitId)
    {
        await using var context = new ProjectDbContext();
        return await context.Visits.FirstOrDefaultAsync(v => v.Id.Equals(visitId));
    }

    public async Task<Visit?> UpdateVisit(Visit newVisit)
    {
        await using var context = new ProjectDbContext();
        var visit = await GetVisit(newVisit.Id);
        if (visit == null)
        {
            return null;
        }
        visit.Reservant = newVisit.Reservant;
        visit.GuestCount = newVisit.GuestCount;
        visit.StartDateTime = newVisit.StartDateTime;
        visit.EndDateTime = newVisit.EndDateTime;
        visit.Orders = newVisit.Orders;
        context.Visits.Update(visit);
        await context.SaveChangesAsync();
        return visit;
    }

    public async Task<Visit?> DeleteVisit(Guid visitId)
    {
        await using var context = new ProjectDbContext();
        var visit = await GetVisit(visitId);
        if (visit == null) return null;
        context.Visits.Remove(visit);
        await context.SaveChangesAsync();
        return visit;
    }
}
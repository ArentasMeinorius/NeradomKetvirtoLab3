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

    public Visit? AddVisit(Visit newVisit)
    {
        using var context = new ProjectDbContext();
        context.Visits.Add(newVisit);
        context.SaveChanges();
        return newVisit;
    }

    public Visit? GetVisit(Guid visitId)
    {
        using var context = new ProjectDbContext();
        return context.Visits.FirstOrDefault(v => v.Id.Equals(visitId));
    }

    public Visit? UpdateVisit(Visit newVisit)
    {
        using var context = new ProjectDbContext();
        var visit = context.Visits.FirstOrDefault(visit => visit.Id.Equals(newVisit.Id));
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
        context.SaveChanges();
        return visit;
    }

    public Visit? DeleteVisit(Guid visitId)
    {
        using var context = new ProjectDbContext();
        var visit = context.Visits.FirstOrDefault(v => v.Id.Equals(visitId));
        if (visit == null) return null;
        context.Visits.Remove(visit);
        return visit;
    }
}
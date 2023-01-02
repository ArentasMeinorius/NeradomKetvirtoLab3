using Microsoft.EntityFrameworkCore;
using NeradomKetvirtoLab3.Database;
using NeradomKetvirtoLab3.Models;

namespace NeradomKetvirtoLab3.Repositories;

public class UsersRepository : IUsersRepository
{
    public UsersRepository()
    {
        using var context = new ProjectDbContext();
        var users = new List<User>
            {
                new()
                {
                    Id = new Guid("5fb7097c-335c-4d07-b4fd-000004e2d28c"), // Pre-defined user id. Same used in user auths
                    Role = "customer",
                    FirstName = "John",
                    DeliveryAddress = new Address
                    {
                        Id = Guid.NewGuid(),
                        CityStreetId = new CityStreets
                        {
                            Id = Guid.NewGuid(),
                            CityId = new City
                            {
                                Id = Guid.NewGuid(),
                                Title = "New York"
                            },
                            StreetId = new Street
                            {
                                Id = Guid.NewGuid(),
                                Title = "Broadway"
                            }
                        },
                        HouseNumber = 123,
                        ApartmentNumber = 456
                    },
                    Orders = new Order[]
                    {
                        new Order()
                        {
                            Id = Guid.NewGuid(),
                            OrderStatus = OrderStatus.Active,
                            Comment = "Please deliver as soon as possible",
                            OrderItems = new Consumable[]
                            {
                                new Consumable()
                                {
                                    Id = Guid.NewGuid(),
                                    Title = "Pizza Margherita",
                                    Description = "Classic margherita pizza with tomato sauce, mozzarella, and basil",
                                    Recipe = new Recipe[]
                                    {
                                        new Recipe()
                                        {
                                            Id = Guid.NewGuid(),
                                            IngredientId = new Ingredient[]
                                            {
                                                new Ingredient()
                                                {
                                                    Id = Guid.NewGuid(),
                                                    Title = "Tomato sauce",
                                                    Units = 200,
                                                    Measurement = Measurement.Milliliter
                                                },
                                                new Ingredient()
                                                {
                                                    Id = Guid.NewGuid(),
                                                    Title = "Mozzarella",
                                                    Units = 100,
                                                    Measurement = Measurement.Gram
                                                },
                                                new Ingredient()
                                                {
                                                    Id = Guid.NewGuid(),
                                                    Title = "Basil",
                                                    Units = 10,
                                                    Measurement = Measurement.Gram
                                                }
                                            }
                                        }
                                    },
                                    Price = 15
                                }
                            },
                            EstimatedDeliveryTime = DateTime.Now.AddHours(1),
                            PaymentMethod = PaymentMethod.Card,
                            Paid = 15
                        }
                    },
                    Reservations = new Reservation[]
                    {
                        new Reservation()
                        {
                            Id = Guid.NewGuid(),
                            Date = DateTime.Now,
                            Time = "18:00",
                            Procedure = new Procedure()
                            {
                                Id = Guid.NewGuid(),
                                Description = "Haircut",
                                Price = 50,
                                EstimatedDuration = "1 hour"
                            },
                            PaymentMethod = PaymentMethod.Card,
                            Tip = 10,
                            Status = ReservationStatus.Reserved
                        }
                    },
                    LoayaltyFeatures = new DiscountCondition()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Gold member"
                    }
                }
            };
        context.Users.AddRange(users);
        context.SaveChanges();
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        await using var context = new ProjectDbContext();
        return await context.Users.ToListAsync();
    }

    public async Task<User?> Update(User newUser)
    {
        await using var context = new ProjectDbContext();
        context.Users.Update(newUser);
        await context.SaveChangesAsync();
        return newUser;
    }
}
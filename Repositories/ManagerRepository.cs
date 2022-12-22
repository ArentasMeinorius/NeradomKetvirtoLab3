using NeradomKetvirtoLab3.Database;
using NeradomKetvirtoLab3.Models;
using Microsoft.EntityFrameworkCore;

namespace NeradomKetvirtoLab3.Repositories;

    public class ManagerRepository : IManagerRepository
    {
    public ManagerRepository()
    {
        using (var context = new ProjectDbContext())
        {
            var tables = new List<Table>
            {
                new Table
                {
                    Id = Guid.NewGuid(),
                    SeatCount = 4,
                    IsOccupied = true
                },
                new Table
                {
                    Id = Guid.NewGuid(),
                    SeatCount = 6,
                    IsOccupied = false
                }
            };
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
            var orders = new List<Order>
            {
                new Order
                {
                    Id = Guid.NewGuid(),
                    OrderStatus = OrderStatus.Active,
                    Comment = "No comment.",
                    OrderItems = new Consumable[]
                    {
                        new Consumable
                        {
                            Id = Guid.NewGuid(),
                            Title = "Bread with cheese",
                            Description = "A delicious appetizer.",
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
                                            Title = "Bread",
                                            Units = 350,
                                            Measurement = Measurement.Gram
                                        },
                                        new Ingredient
                                        {
                                            Id = Guid.NewGuid(),
                                            Title = "Cheese",
                                            Units = 100,
                                            Measurement = Measurement.Gram
                                        },
                                        new Ingredient
                                        {
                                            Id = Guid.NewGuid(),
                                            Title = "Salt",
                                            Units = 10,
                                            Measurement = Measurement.Gram
                                        }
                                    }
                                }
                            },
                            Price = 5
                        },
                        new Consumable
                        {
                            Id = Guid.NewGuid(),
                            Title = "Cold water",
                            Description = "A refreshing drink.",
                            Price = 1
                        }
                    },
                    EstimatedDeliveryTime = DateTime.Now.AddMinutes(15),
                    PaymentMethod = PaymentMethod.Card,
                    Paid = 6
                }
            };
            var users = new List<User>
            {
                new User()
                {
                    Id = Guid.NewGuid(),
                    Role = "customer",
                    FirstName = "John",
                    DeliveryAddress = new Address()
                    {
                        Id = Guid.NewGuid(),
                        CityStreetId = new CityStreets()
                        {
                            Id = Guid.NewGuid(),
                            CityId = new City()
                            {
                                Id = Guid.NewGuid(),
                                Title = "New York"
                            },
                            StreetId = new Street()
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
            var usersAuths = new List<UserAuth>()
            {
                new UserAuth
                {
                    Id = users.First().Id,
                    SecurityCode = "abc123"
                }
            };

            context.Tables.AddRange(tables);
            context.Consumables.AddRange(consumables);
            context.Visits.AddRange(visits);
            context.Orders.AddRange(orders);
            context.Users.AddRange(users);
            context.UsersAuths.AddRange(usersAuths);
            context.SaveChanges();
            }
        }

    public Table? UpdateTable(Table newTable)
    {
        using var context = new ProjectDbContext();
        var table = context.Tables.Where(table => table.Id.Equals(newTable.Id)).FirstOrDefault();
        if (table == null)
        {
            return null;
        }
        table.SeatCount = newTable.SeatCount;
        table.IsOccupied = newTable.IsOccupied;
        context.Tables.Update(table);
        context.SaveChanges();
        return table;
    }
    public Consumable? UpdateConsumable(Consumable newConsumable)
    {
        using var context = new ProjectDbContext();
        var consumable = context.Consumables.Where(consumable => consumable.Id.Equals(newConsumable.Id)).FirstOrDefault();
        if (consumable == null)
        {
            return null;
        }
        consumable.Title = newConsumable.Title;
        consumable.Description = newConsumable.Description;
        consumable.Recipe = newConsumable.Recipe;
        consumable.Price = newConsumable.Price;
        context.Consumables.Update(consumable);
        context.SaveChanges();
        return consumable;
    }

    public Visit? UpdateVisit(Visit newVisit)
    {
        using var context = new ProjectDbContext();
        var visit = context.Visits.Where(visit => visit.Id.Equals(newVisit.Id)).FirstOrDefault();
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

    public Order? MarkOrderAsComplete(Guid orderId)
    {
        using var context = new ProjectDbContext();
        var order = context.Orders.Where(order => order.Id.Equals(orderId)).FirstOrDefault(); 
        if (order == null) 
        {
            return null;
        }
        order.OrderStatus = OrderStatus.Completed;
        context.Orders.Update(order);
        context.SaveChanges();
        return order;
    }

    public Order? DeclineOrder(Guid orderId)
    {
        using var context = new ProjectDbContext();
        var order = context.Orders.Where(order => order.Id.Equals(orderId)).FirstOrDefault();
        if (order == null)
        {
            return null;
        }
        order.OrderStatus = OrderStatus.Declined;
        context.Orders.Update(order);
        context.SaveChanges();
        return order;
    }


    public List<Order> GetOrders(Guid orderId, string searchString, int pageIndex, int pageSize)
    {
        using var context = new ProjectDbContext();


        var orderList = context.Orders
        .Where(order => order.Id.Equals(orderId))
        .Skip((pageIndex - 1) * pageSize)
        .Take(pageSize)
        .ToList();

        orderList.AddRange(context.Orders
            .Where(order =>
                order.Comment.ToLower().Contains(searchString.ToLower()) ||
                Enum.ToObject(typeof(OrderStatus), order.OrderStatus).ToString().ToLower().Contains(searchString.ToLower()) ||
                order.EstimatedDeliveryTime.ToString().Contains(searchString.ToLower()) ||
                order.PaymentMethod.ToString().ToLower().Contains(searchString.ToLower()) ||
                order.Paid.ToString().Contains(searchString.ToLower()))
            .Include(a => a.OrderItems)
            .ThenInclude(a => a.Recipe)
            .ThenInclude(a => a.IngredientId)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize));

        return orderList.Distinct().ToList();
    }

    public Order? UpdateOrder(Order newOrder)
    {
        using var context = new ProjectDbContext();
        var order = context.Orders.Where(order => order.Id.Equals(newOrder.Id)).FirstOrDefault();
        if (order == null)
        {
            return null;
        }
        order.OrderStatus = newOrder.OrderStatus;
        order.OrderItems = newOrder.OrderItems;
        order.PaymentMethod = newOrder.PaymentMethod;
        order.Comment = newOrder.Comment;
        order.EstimatedDeliveryTime = newOrder.EstimatedDeliveryTime;
        context.Orders.Update(order);
        context.SaveChanges();
        return order;
    }

    public User? AddRole(Guid userId, string role)
    {
        using var context = new ProjectDbContext();
        var user = context.Users.Where(user => userId.Equals(userId)).FirstOrDefault();
        if (user == null)
        {
            return null;
        }
        user.Role = role;
        context.Users.Update(user);
        context.SaveChanges();
        return user;
    }

    public UserWithAuth? Authenticate(UserAuth newUserAuth) 
    {
        using var context = new ProjectDbContext();
        var userAuth = context.UsersAuths
            .Where(user => user.Id
            .Equals(newUserAuth.Id) && user.SecurityCode
            .Equals(newUserAuth.SecurityCode))
            .FirstOrDefault();
        if (userAuth == null)
        {
            return null;
        }
        var user = context.Users
            .Where(user => user.Id
            .Equals(userAuth.Id))
            .FirstOrDefault();
        if (user == null)
        {
            return null;
        }

        return new UserWithAuth(user, userAuth.SecurityCode);
    }

}

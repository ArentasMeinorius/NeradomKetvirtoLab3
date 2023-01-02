using Microsoft.EntityFrameworkCore;
using NeradomKetvirtoLab3.Database;
using NeradomKetvirtoLab3.Models;

namespace NeradomKetvirtoLab3.Repositories;

public class OrdersRepository : IOrdersRepository
{
    public OrdersRepository()
    {
        using var context = new ProjectDbContext();

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
                Paid = 6,
                Discounts = new List<Discounts>(),
            }
        };
        
        context.Orders.AddRange(orders);
        context.SaveChanges();
    }

    public async Task<Order?> AddOrder(Order newOrder)
    {
        await using var context = new ProjectDbContext();
        await context.Orders.AddAsync(newOrder);
        await context.SaveChangesAsync();
        return newOrder;
    }

    public async Task<Order?> Update(Order newOrder)
    {
        await using var context = new ProjectDbContext();
        var order = await context.Orders.FirstOrDefaultAsync(order => order.Id.Equals(newOrder.Id));
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
        await context.SaveChangesAsync();
        return order;
    }

    public async Task<IEnumerable<Order>> GetPaginated(Guid orderId, string searchString, int pageIndex, int pageSize)
    {
        await using var context = new ProjectDbContext();

        var orderList = await context.Orders
            .Where(order => order.Id.Equals(orderId))
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        orderList.AddRange(await context.Orders
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
            .Take(pageSize)
            .ToListAsync());

        return orderList.Distinct().ToList();
    }

    public async Task<IEnumerable<Order>> GetAll()
    {
        await using var context = new ProjectDbContext();
        return await context.Orders.ToListAsync();
    }

    public async Task<Order?> GetOrder(Guid orderId)
    {
        await using var context = new ProjectDbContext();
        return await context.Orders.FirstOrDefaultAsync(o => o.Id.Equals(orderId));
    }

    public async Task<Order?> DeleteOrder(Guid orderId)
    {
        await using var context = new ProjectDbContext();
        var order = await context.Orders.FirstOrDefaultAsync(o => o.Id.Equals(orderId));
        if (order == null) return null;
        context.Orders.Remove(order);
        await context.SaveChangesAsync();
        return order;
    }
}
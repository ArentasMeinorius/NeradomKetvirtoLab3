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

    public Order? AddOrder(Order newOrder)
    {
        using var context = new ProjectDbContext();
        context.Orders.Add(newOrder);
        context.SaveChanges();
        return newOrder;
    }

    public Order? Update(Order newOrder)
    {
        using var context = new ProjectDbContext();
        var order = context.Orders.FirstOrDefault(order => order.Id.Equals(newOrder.Id));
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

    public IEnumerable<Order> GetPaginated(Guid orderId, string searchString, int pageIndex, int pageSize)
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

    public IEnumerable<Order> GetAll()
    {
        using var context = new ProjectDbContext();
        return context.Orders;
    }

    public Order? DeleteOrder(Guid orderId)
    {
        using var context = new ProjectDbContext();
        var order = context.Orders.FirstOrDefault(o => o.Id.Equals(orderId));
        if (order == null) return null;
        context.Orders.Remove(order);
        return order;
    }
}
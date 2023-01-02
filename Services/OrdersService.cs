using NeradomKetvirtoLab3.Models;
using NeradomKetvirtoLab3.Repositories;

namespace NeradomKetvirtoLab3.Services;

public class OrdersService : IOrdersService
{
    private readonly IOrdersRepository _ordersRepository;
    
    public OrdersService(IOrdersRepository ordersRepository)
    {
        _ordersRepository = ordersRepository;
    }

    public Order? AddOrder(Order newOrder)
        => _ordersRepository.AddOrder(newOrder);

    public Order? Update(Order newOrder)
        => _ordersRepository.Update(newOrder);

    public IEnumerable<Order> GetPaginated(Guid orderId, string searchString, int pageIndex, int pageSize)
        => _ordersRepository.GetPaginated(orderId, searchString, pageIndex, pageIndex);

    public Order? DeleteOrder(Guid orderId)
        => _ordersRepository.DeleteOrder(orderId);

    public Order? MarkOrderAsComplete(Guid orderId)
    {
        var order = _ordersRepository.GetAll().FirstOrDefault(order => order.Id.Equals(orderId));
        if (order == null)
        {
            return null;
        }
        order.OrderStatus = OrderStatus.Completed;
        Update(order);
        return order;
    }

    public Order? DeclineOrder(Guid orderId)
    {
        var order = _ordersRepository.GetAll().FirstOrDefault(order => order.Id.Equals(orderId));
        if (order == null)
        {
            return null;
        }
        order.OrderStatus = OrderStatus.Declined;
        Update(order);
        return order;
    }

    public Order? AddComment(Guid orderId, string comment)
    {
        var order = _ordersRepository.GetAll().FirstOrDefault(order => order.Id.Equals(orderId));
        if (order == null)
        {
            return null;
        }
        order.Comment = comment;
        order.OrderStatus = OrderStatus.Completed;
        Update(order);
        return order;
    }

    public Order? AddDiscount(Guid orderId, Discounts discount)
    {
        var order = _ordersRepository.GetAll().FirstOrDefault(order => order.Id.Equals(orderId));
        if (order == null)
        {
            return null;
        }
        order.Discounts.Add(discount);
        Update(order);
        return order;
    }
}
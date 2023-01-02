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

    public async Task<Order?> AddOrder(Order newOrder)
        => await _ordersRepository.AddOrder(newOrder);

    public async Task<Order?> Update(Order newOrder)
        => await _ordersRepository.Update(newOrder);

    public async Task<IEnumerable<Order>> GetPaginated(Guid orderId, string searchString, int pageIndex, int pageSize)
        => await _ordersRepository.GetPaginated(orderId, searchString, pageIndex, pageIndex);

    public async Task<Order?> DeleteOrder(Guid orderId)
        => await _ordersRepository.DeleteOrder(orderId);

    public async Task<Order?> MarkOrderAsComplete(Guid orderId)
    {
        var order = await _ordersRepository.GetOrder(orderId);
        if (order == null)
        {
            return null;
        }
        order.OrderStatus = OrderStatus.Completed;
        await Update(order);
        return order;
    }

    public async Task<Order?> DeclineOrder(Guid orderId)
    {
        var order = await _ordersRepository.GetOrder(orderId);
        if (order == null)
        {
            return null;
        }
        order.OrderStatus = OrderStatus.Declined;
        await Update(order);
        return order;
    }

    public async Task<Order?> AddComment(Guid orderId, string comment)
    {
        var order = await _ordersRepository.GetOrder(orderId);
        if (order == null)
        {
            return null;
        }
        order.Comment = comment;
        order.OrderStatus = OrderStatus.Completed;
        await Update(order);
        return order;
    }

    public async Task<Order?> AddDiscount(Guid orderId, Discounts discount)
    {
        var order = await _ordersRepository.GetOrder(orderId);
        if (order == null)
        {
            return null;
        }
        order.Discounts.Add(discount);
        await Update(order);
        return order;
    }
}
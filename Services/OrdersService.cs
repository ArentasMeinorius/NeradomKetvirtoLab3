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

    public Order? Update(Order newOrder)
        => _ordersRepository.Update(newOrder);

    public IEnumerable<Order> GetPaginated(Guid orderId, string searchString, int pageIndex, int pageSize)
        => _ordersRepository.GetPaginated(orderId, searchString, pageIndex, pageIndex);

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
}
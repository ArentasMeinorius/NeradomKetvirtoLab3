using NeradomKetvirtoLab3.Models;

namespace NeradomKetvirtoLab3.Services;

public interface IOrdersService
{
    Order? AddOrder(Order newOrder);

    public Order? Update(Order newOrder);
    
    IEnumerable<Order> GetPaginated(Guid orderId, string searchString, int pageIndex, int pageSize);

    public Order? MarkOrderAsComplete(Guid orderId);

    public Order? DeclineOrder(Guid orderId);

    Order? AddComment(Guid orderId, string comment);
    Order? AddDiscount(Guid orderId, Discounts discount);
    Order? DeleteOrder(Guid orderId);
}
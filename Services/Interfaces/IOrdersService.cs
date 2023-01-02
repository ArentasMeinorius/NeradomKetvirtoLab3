using NeradomKetvirtoLab3.Models;

namespace NeradomKetvirtoLab3.Services;

public interface IOrdersService
{
    Task<Order?> AddOrder(Order newOrder);

    Task<Order?> Update(Order newOrder);
    
    Task<IEnumerable<Order>> GetPaginated(Guid orderId, string searchString, int pageIndex, int pageSize);

    Task<Order?> MarkOrderAsComplete(Guid orderId);

    Task<Order?> DeclineOrder(Guid orderId);

    Task<Order?> AddComment(Guid orderId, string comment);

    Task<Order?> AddDiscount(Guid orderId, Discounts discount);

    Task<Order?> DeleteOrder(Guid orderId);
}
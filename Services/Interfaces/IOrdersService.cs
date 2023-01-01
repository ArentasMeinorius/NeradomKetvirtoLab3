using NeradomKetvirtoLab3.Models;

namespace NeradomKetvirtoLab3.Services;

public interface IOrdersService
{
    public Order? Update(Order newOrder);
    
    IEnumerable<Order> GetPaginated(Guid orderId, string searchString, int pageIndex, int pageSize);

    public Order? MarkOrderAsComplete(Guid orderId);

    public Order? DeclineOrder(Guid orderId);
}
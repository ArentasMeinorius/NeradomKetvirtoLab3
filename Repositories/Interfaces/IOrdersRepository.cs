using NeradomKetvirtoLab3.Models;

namespace NeradomKetvirtoLab3.Repositories;

public interface IOrdersRepository
{
    Task<Order?> Update(Order newOrder);

    Task<IEnumerable<Order>> GetPaginated(Guid orderId, string searchString, int pageIndex, int pageSize);

    Task<IEnumerable<Order>> GetAll();

    Task<Order?> AddOrder(Order newOrder);

    Task<Order?> DeleteOrder(Guid orderId);

    Task<Order?> GetOrder(Guid orderId);
}
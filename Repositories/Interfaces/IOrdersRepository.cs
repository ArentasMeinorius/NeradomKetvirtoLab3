using NeradomKetvirtoLab3.Models;

namespace NeradomKetvirtoLab3.Repositories;

public interface IOrdersRepository
{
    public Order? Update(Order newOrder);

    IEnumerable<Order> GetPaginated(Guid orderId, string searchString, int pageIndex, int pageSize);

    IEnumerable<Order> GetAll();
}
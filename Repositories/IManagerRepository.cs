using NeradomKetvirtoLab3.Models;

namespace NeradomKetvirtoLab3.Repositories;

    public interface IManagerRepository
    {
        Table? UpdateTable(Table newTable);

        Consumable? UpdateConsumable(Consumable newConsumable);

        Visit? UpdateVisit(Visit newVisit);

        Order? MarkOrderAsComplete(Guid orderId);

        Order? DeclineOrder(Guid orderId);

        List<Order> GetOrders(Guid orderId, string searchString, int pageIndex, int pageSize);

        Order? UpdateOrder(Order newOrder);

        User? AddRole(Guid userId, string role);

        UserWithAuth? Authenticate(UserAuth newUserAuth);

    }

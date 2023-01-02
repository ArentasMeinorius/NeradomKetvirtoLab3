using NeradomKetvirtoLab3.Models;

namespace NeradomKetvirtoLab3.Repositories;

public interface IConsumablesRepository
{
    Task<IEnumerable<Consumable>> GetAll();

    Task<Consumable?> Update(Consumable newConsumable);
}
using NeradomKetvirtoLab3.Models;

namespace NeradomKetvirtoLab3.Services;

public interface IConsumablesService
{
    Task<IEnumerable<Consumable>> GetAllConsumables();
    Task<Consumable?> Update(Consumable newConsumable);
}
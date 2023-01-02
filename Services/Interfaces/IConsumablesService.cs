using NeradomKetvirtoLab3.Models;

namespace NeradomKetvirtoLab3.Services;

public interface IConsumablesService
{
    IEnumerable<Consumable> GetAllConsumables();
    public Consumable? Update(Consumable newConsumable);
}
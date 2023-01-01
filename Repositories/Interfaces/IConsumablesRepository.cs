using NeradomKetvirtoLab3.Models;

namespace NeradomKetvirtoLab3.Repositories;

public interface IConsumablesRepository
{
    public Consumable? Update(Consumable newConsumable);
}
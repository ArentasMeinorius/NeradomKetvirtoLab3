using NeradomKetvirtoLab3.Models;

namespace NeradomKetvirtoLab3.Repositories;

public interface IConsumablesRepository
{
    IEnumerable<Consumable> GetAll();
    public Consumable? Update(Consumable newConsumable);
}
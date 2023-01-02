using NeradomKetvirtoLab3.Models;
using NeradomKetvirtoLab3.Repositories;

namespace NeradomKetvirtoLab3.Services;

public class ConsumablesService : IConsumablesService
{
    private readonly IConsumablesRepository _consumablesRepository;
    
    public ConsumablesService(IConsumablesRepository consumablesRepository)
    {
        _consumablesRepository = consumablesRepository;
    }

    public Consumable? Update(Consumable newConsumable)
        => _consumablesRepository.Update(newConsumable);

    public IEnumerable<Consumable> GetAllConsumables()
        => _consumablesRepository.GetAll();
}
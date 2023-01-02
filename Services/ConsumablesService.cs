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

    public async Task<Consumable?> Update(Consumable newConsumable)
        => await _consumablesRepository.Update(newConsumable);

    public async Task<IEnumerable<Consumable>> GetAllConsumables()
        => await _consumablesRepository.GetAll();
}
using NeradomKetvirtoLab3.Models;
using NeradomKetvirtoLab3.Repositories;

namespace NeradomKetvirtoLab3.Services;

public class VisitsService : IVisitsService
{
    private readonly IVisitsRepository _visitsRepository;
    
    public VisitsService(IVisitsRepository visitsRepository)
    {
        _visitsRepository = visitsRepository;
    }

    public Visit? UpdateVisit(Visit newVisit)
        => _visitsRepository.UpdateVisit(newVisit);
}
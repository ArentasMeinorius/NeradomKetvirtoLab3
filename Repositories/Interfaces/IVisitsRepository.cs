using NeradomKetvirtoLab3.Models;

namespace NeradomKetvirtoLab3.Repositories;

public interface IVisitsRepository
{
    Visit? AddVisit(Visit newVisit);
    Visit? DeleteVisit(Guid visitId);
    Visit? GetVisit(Guid visitId);
    public Visit? UpdateVisit(Visit newVisit);
}
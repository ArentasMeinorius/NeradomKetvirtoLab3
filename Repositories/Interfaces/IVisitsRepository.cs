using NeradomKetvirtoLab3.Models;

namespace NeradomKetvirtoLab3.Repositories;

public interface IVisitsRepository
{
    Task<Visit?> AddVisit(Visit newVisit);
    Task<Visit?> DeleteVisit(Guid visitId);
    Task<Visit?> GetVisit(Guid visitId);
    Task<Visit?> UpdateVisit(Visit newVisit);
}
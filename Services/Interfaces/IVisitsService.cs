using NeradomKetvirtoLab3.Models;

namespace NeradomKetvirtoLab3.Services;

public interface IVisitsService
{
    Task<Visit?> AddVisit(Visit newVisit);

    Task<Visit?> DeleteVisit(Guid visitId);

    Task<Visit?> UpdateVisit(Visit newVisit);

    Task<decimal?> CalculateReceipt(Guid visitId);
}
using NeradomKetvirtoLab3.Models;

namespace NeradomKetvirtoLab3.Services;

public interface IVisitsService
{
    Visit? AddVisit(Visit newVisit);
    decimal? CalculateReceipt(Guid visitId);
    Visit? DeleteVisit(Guid visitId);
    public Visit? UpdateVisit(Visit newVisit);
}
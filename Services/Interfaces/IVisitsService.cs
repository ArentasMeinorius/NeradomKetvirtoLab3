using NeradomKetvirtoLab3.Models;

namespace NeradomKetvirtoLab3.Services;

public interface IVisitsService
{
    public Visit? UpdateVisit(Visit newVisit);
}
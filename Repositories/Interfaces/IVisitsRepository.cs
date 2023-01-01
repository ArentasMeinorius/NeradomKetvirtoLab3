using NeradomKetvirtoLab3.Models;

namespace NeradomKetvirtoLab3.Repositories;

public interface IVisitsRepository
{
    public Visit? UpdateVisit(Visit newVisit);
}
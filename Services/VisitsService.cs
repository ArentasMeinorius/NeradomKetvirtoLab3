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

    public async Task<Visit?> AddVisit(Visit newVisit)
        => await _visitsRepository.AddVisit(newVisit);

    public async Task<Visit?> UpdateVisit(Visit newVisit)
        => await _visitsRepository.UpdateVisit(newVisit);

    public async Task<Visit?> DeleteVisit(Guid visitId)
        => await _visitsRepository.DeleteVisit(visitId);

    public async Task<decimal?> CalculateReceipt(Guid visitId)
    {
        var visit = await _visitsRepository.GetVisit(visitId);
        if (visit == null)
        {
            return null;
        }

        decimal totalPrice = 0;
        foreach (var order in visit.Orders)
        {
            foreach (var item in order.OrderItems)
            {
                var itemPrice = item.Price;
                var applicableDiscounts = order.Discounts.Where(d => d.Item.Id.Equals(item.Id));
                foreach (var discount in applicableDiscounts)
                {
                    itemPrice *= discount.Percentage / 100.0m;
                }
                totalPrice += itemPrice;
            }
        }

        return totalPrice;
    }
}
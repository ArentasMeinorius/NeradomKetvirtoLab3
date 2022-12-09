namespace NeradomKetvirtoLab3.Models;

public class User
{
    public Guid Id { get; set; }
    public string Role { get; set; }
    public string FirstName { get; set; }
    public Address DeliveryAddress { get; set; }
    public Order[] Orders { get; set; }
    public Reservation[] Reservations { get; set; }
    public DiscountCondition LoayaltyFeatures { get; set; }
}
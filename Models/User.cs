namespace NeradomKetvirtoLab3.Models;

public class User
{
    public Guid Id { get; set; }
    public string Role { get; set; }
    public string FirstName { get; set; }
    public Address DeliveryAddress { get; set; }
    public ICollection<Order> Orders { get; set; }
    public ICollection<Reservation> Reservations { get; set; }
    public DiscountCondition LoayaltyFeatures { get; set; }
}
namespace NeradomKetvirtoLab3.Models;

public class Order
{
    public Guid Id { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public string Comment { get; set; }
    public ICollection<Consumable> OrderItems { get; set; }
    public DateTime EstimatedDeliveryTime { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public decimal Paid { get; set; }

}

public enum OrderStatus
{
    Active,
    Accepted,
    InProgress,
    Completed,
    InDelivery,
    Delivered,
    Declined,
    Refunded
}
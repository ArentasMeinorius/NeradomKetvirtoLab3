namespace NeradomKetvirtoLab3.Models;

public class Visit
{
    public Guid Id { get; set; }
    public Table TableId { get; set; }
    public Reservant Reservant { get; set; }
    public int GuestCount { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public Order[] Orders { get; set; }
}
namespace NeradomKetvirtoLab3.Models;

public class Reservation
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public string Time { get; set; }

    public Procedure Procedure { get; set; }
    public PaymentMethod PaymentMethod { get; set; }
    public decimal Tip { get; set; }
    public ReservationStatus Status { get; set; }
}

public enum PaymentMethod
{
    Card,
    Cash,
    Online
}

public enum ReservationStatus
{
    Reserved,
    InProgress,
    Cancelled,
    Completed
}
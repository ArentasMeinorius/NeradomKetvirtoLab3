namespace NeradomKetvirtoLab3.Models;

public class Address
{
    public Guid Id { get; set; }
    public CityStreets CityStreetId { get; set; }
    public int HouseNumber { get; set; }
    public int ApartmentNumber { get; set; }
}
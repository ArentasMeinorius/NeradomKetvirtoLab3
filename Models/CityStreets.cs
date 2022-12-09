namespace NeradomKetvirtoLab3.Models;

public class CityStreets
{
    public Guid Id { get; set; }
    public City CityId { get; set; }
    public Street StreetId { get; set; }
}
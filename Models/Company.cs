namespace NeradomKetvirtoLab3.Models;

public class Company
{
    public string CompanyCode { get; set; }
    public string Title { get; set; }
    public Address Address { get; set; }
    public string Website { get; set; }
    public ICollection<User> Employees { get; set; }
}
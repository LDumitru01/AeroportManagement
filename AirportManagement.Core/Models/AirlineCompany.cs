using AirportManagement.Core.Enums;

namespace AirportManagement.Core.Models;

public class AirlineCompany
{
    public int Id { get; set; }
    public AirlineCompanyName Name { get; set; }
    public List<Pilot> Pilots { get; set; } = new();
    public List<Stewardess> Stewardesses { get; set; } = new();

    public AirlineCompany(AirlineCompanyName name)
    {
        Name = name;
    }

}
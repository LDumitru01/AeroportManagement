using System.ComponentModel.DataAnnotations;

namespace AirportManagement.Core.Models;

public class Passenger
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string PassportNumber { get; set; }
    public List<int> BookedFlightsIds { get; set; } = new(); //O Lista  cu ID-urile zborurilor rezervate //Respectam SRP Solid
    
    public Passenger(string name, string passportNumber)
    {
        Name = name;
        PassportNumber = passportNumber;
    }
}
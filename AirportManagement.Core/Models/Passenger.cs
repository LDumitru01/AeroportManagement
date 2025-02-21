using System.ComponentModel.DataAnnotations;

namespace AirportManagement.Core.Models;

public class Passenger
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string PassportNumber { get; set; }
}
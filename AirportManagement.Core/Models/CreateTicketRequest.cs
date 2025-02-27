using AirportManagement.Core.Enums;

namespace AirportManagement.Core.Models;

public class CreateTicketRequest
{
    public int FlightId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PassportNumber { get; set; }
    public SeatType Seat { get; set; }
    public MealType MealOption { get; set; }
}
using AirportManagement.Core.Enums;

namespace AirportManagement.Core.Models;

public class CreateTicketRequest
{
    public int FlightId { get; set; }
    public MealType MealOption { get; set; }
    public SeatType Seat { get; set; }
}
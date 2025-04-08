using AirportManagement.Core.Enums;

namespace AirportManagement.Core.Models;

public class CreateTicketRequest
{
    public CreateTicketRequest(int flightId, string firstName, string lastName, string passportNumber, SeatType seat, MealType mealOption, double? luggageWeight)
    {
        FlightId = flightId;
        FirstName = firstName;
        LastName = lastName;
        PassportNumber = passportNumber;
        Seat = seat;
        MealOption = mealOption;
        LuggageWeight = luggageWeight;
    }

    public int FlightId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PassportNumber { get; set; }
    public SeatType Seat { get; set; }
    public MealType MealOption { get; set; }
    
    public double? LuggageWeight { get; set; }
}
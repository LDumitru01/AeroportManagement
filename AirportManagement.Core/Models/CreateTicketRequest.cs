using AirportManagement.Core.Enums;

namespace AirportManagement.Core.Models;

public class CreateTicketRequest
{
    public CreateTicketRequest(string flightNumber, string firstName, string lastName, string passportNumber, SeatType seat, MealType mealOption, double? luggageWeight)
    {
        FlightNumber = flightNumber;
        FirstName = firstName;
        LastName = lastName;
        PassportNumber = passportNumber;
        Seat = seat;
        MealOption = mealOption;
        LuggageWeight = luggageWeight;
    }

    public string FlightNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PassportNumber { get; set; }
    public SeatType Seat { get; set; }
    public MealType MealOption { get; set; }
    
    public double? LuggageWeight { get; set; }
}
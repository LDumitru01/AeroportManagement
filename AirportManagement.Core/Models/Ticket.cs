using AirportManagement.Core.Enums;

namespace AirportManagement.Core.Models;

public class Ticket
{
    public int Id { get; set; } // Primary Key
    public Flight Flight { get; set; }
    public SeatType Seat { get; set; }
    public MealType MealOption { get; set; }

    // Constructor folosit de Builder
    public Ticket(Flight flight, MealType mealOption, SeatType seat)
    {
        Flight = flight;
        MealOption = mealOption;
        Seat = seat;
    }
    
    private Ticket(){}
}
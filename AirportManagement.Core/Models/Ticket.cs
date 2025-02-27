using AirportManagement.Core.Enums;
using AirportManagement.Core.Interfaces;

namespace AirportManagement.Core.Models
{
    public class Ticket : IPrototype<Ticket>
    {
        public int Id { get; set; }
        public Flight? Flight { get; set; }
        public Passenger? Passenger { get; set; }
        public SeatType Seat { get; set; }
        public MealType MealOption { get; set; }
        
        public Ticket() {}

        public Ticket(Flight? flight, Passenger? passenger, MealType mealOption, SeatType seat)
        {
            Flight = flight;
            Passenger = passenger;
            MealOption = mealOption;
            Seat = seat;
        }
        public Ticket Clone(string newFirstName, string newLastName, string newPassportNumber)
        {
            return new Ticket(Flight, new Passenger(newFirstName, newLastName, newPassportNumber), MealOption, Seat);
        }
        
    }
}
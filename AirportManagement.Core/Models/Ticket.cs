using System.ComponentModel.DataAnnotations.Schema;
using AirportManagement.Core.Decorator;
using AirportManagement.Core.Enums;
using AirportManagement.Core.Interfaces;
using AirportManagement.Core.Models.FlyWeightPattern;

namespace AirportManagement.Core.Models
{
    public class Ticket : IPrototype<Ticket>, ITicketComponent
    {
        public int Id { get; set; }
        public Flight? Flight { get; set; }
        public Passenger? Passenger { get; set; }
        public SeatType Seat { get; set; }
        public MealType MealOption { get; set; }
        public double? LuggageWeight { get; set; }

        [NotMapped] public SeatDetailes SeatDetailes { get; set; }

        public Ticket()
        {
        }

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

        public string GetTicketInfo()
        {
            string info =
                $"Ticket for {Passenger?.FirstName} {Passenger?.LastName}, Flight: {Flight?.FlightNumber}, Seat: {Seat}, Meal: {MealOption}";
            if (LuggageWeight.HasValue)
            {
                info += $", Luggage: {LuggageWeight.Value}kg";
            }

            return info;
        }
    }
}
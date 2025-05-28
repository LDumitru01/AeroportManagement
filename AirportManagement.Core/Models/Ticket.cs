using System.ComponentModel.DataAnnotations.Schema;
using AirportManagement.Core.Decorator;
using AirportManagement.Core.Enums;
using AirportManagement.Core.Interfaces;
using AirportManagement.Core.Models.FlyWeightPattern;
using AirportManagement.Core.Visitor;

namespace AirportManagement.Core.Models
{
    public class Ticket : IPrototype<Ticket>, ITicketComponent, IVisitable
    {
        public int Id { get; set; }
        public Flight? Flight { get; set; }
        public Passenger? Passenger { get; set; }
        public SeatType Seat { get; set; }
        public MealType MealOption { get; set; }
        public double? LuggageWeight { get; set; }
        public bool IsPaid { get; set; } = false;
        public decimal? PaidAmount { get; set; }
        public PaymentMethod? PaymentMethod { get; set; }
        
        public bool IsCheckedIn { get; set; }

        public string CheckInType { get; set; }

        public string PassportType { get; set; }

        public DateTime DateOfBirth { get; set; }
        public int FlightId { get; set; }          // FK
        

        [NotMapped] public SeatDetailes SeatDetailes { get; set; }
        public string Email { get; set; }
        
        public Ticket() { }

        public Ticket(SeatDetailes seatDetailes, string email)
        {
            SeatDetailes = seatDetailes;
            Email = email;
        }

        public Ticket(Flight? flight, Passenger? passenger, MealType mealOption, SeatType seat, SeatDetailes seatDetailes, string email)
        {
            Flight = flight;
            Passenger = passenger;
            MealOption = mealOption;
            Seat = seat;
            SeatDetailes = seatDetailes;
            Email = email;
        }

        public Ticket Clone(string newFirstName, string newLastName, string newPassportNumber)
        {
            return new Ticket(Flight, new Passenger(newFirstName, newLastName, newPassportNumber), MealOption, Seat, SeatDetailes, Email);
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

        public void Accept(IVisitor visitor)
        {
            visitor.VisitTicket(this);
        }
    }
}
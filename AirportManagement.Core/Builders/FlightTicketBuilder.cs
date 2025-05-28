using AirportManagement.Core.Enums;
using AirportManagement.Core.Interfaces;
using AirportManagement.Core.Models;
using AirportManagement.Core.Models.FlyWeightPattern;

namespace AirportManagement.Core.Builders
{
    public class FlightTicketBuilder : ITicketBuilder
    {
        private Flight? _flight;
        private Passenger? _passenger;
        private SeatType _seat;
        private MealType _mealOption;   
        private string _email = "";
        private SeatDetailes _seatDetailes;

        public ITicketBuilder SetFlight(Flight? flight)
        {
            _flight = flight;
            return this;
        }

        public ITicketBuilder SetPassenger(Passenger? passenger)
        {
            _passenger = passenger;
            return this;
        }

        public ITicketBuilder SetMealOption(MealType mealOption)
        {
            _mealOption = mealOption;
            return this;
        }

        public ITicketBuilder SetSeat(SeatType seat)
        {
            _seat = seat;
            return this;
        }
        
        public ITicketBuilder SetEmail(string email)
        {
            _email = email;
            return this;
        }
        
        public ITicketBuilder SetSeatDetailes(SeatDetailes seatDetailes)
        {
            _seatDetailes = seatDetailes;
            return this;
        }

        public Ticket Build()
        {
            return new Ticket(_flight, _passenger, _mealOption, _seat, _seatDetailes, _email);
        }
    }
}
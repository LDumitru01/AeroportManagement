using AirportManagement.Core.Enums;
using AirportManagement.Core.Interfaces;
using AirportManagement.Core.Models;

namespace AirportManagement.Core.Builders
{
    public class FlightTicketBuilder : ITicketBuilder
    {
        private Flight? _flight;
        private Passenger? _passenger;
        private SeatType _seat;
        private MealType _mealOption;

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

        public Ticket Build()
        {
            return new Ticket(_flight, _passenger, _mealOption, _seat);
        }
    }
}
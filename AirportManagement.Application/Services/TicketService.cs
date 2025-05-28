using System.Security.Claims;
using AirportManagement.Application.Interfaces.IRepository;
using AirportManagement.Application.Interfaces.IServices;
using AirportManagement.Core.Builders;
using AirportManagement.Core.Enums;
using AirportManagement.Core.Models;
using AirportManagement.Core.Models.FlyWeightPattern;
using AirportManagement.Core.Strategy;
using Microsoft.AspNetCore.Http;

namespace AirportManagement.Application.Services
{
    public class TicketService : ITicketService
    {
        private readonly IFlightRepository _flightRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly IPassengerRepository _passengerRepository;
        private readonly IPassengerValidationStrategy _validationStrategy;
        private readonly IPassengerValidationStrategySelector _strategySelector;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public TicketService(IFlightRepository flightRepository, ITicketRepository ticketRepository, IPassengerRepository passengerRepository, SeatFlyweightFactory seatFlyweightFactory, IPassengerValidationStrategy validationStrategy, IPassengerValidationStrategySelector strategySelector, IHttpContextAccessor httpContextAccessor)
        {
            _flightRepository = flightRepository;
            _ticketRepository = ticketRepository;
            _passengerRepository = passengerRepository;
            _validationStrategy = validationStrategy;
            _strategySelector = strategySelector;
            _httpContextAccessor = httpContextAccessor;
        }
        
        public async Task<Ticket> CreateTicketAsync(
            string userEmail,
            string flightNumber,
            string firstName,
            string lastName,
            string passportNumber,
            MealType mealOption,
            SeatType seat,
            double? luggageWeight = null)
        {
            var flight = await _flightRepository.GetFlightByNumberAsync(flightNumber);
            if (flight == null)
                throw new ArgumentException("Flight not found.");

            var passenger = await _passengerRepository.GetPassengerByPassportAsync(passportNumber)
                            ?? new Passenger(firstName, lastName, passportNumber);

            var validationStrategy = _strategySelector.SelectStrategy(flight);

            if (!await validationStrategy.ValidatePassengerAsync(passenger, flight))
                throw new InvalidOperationException("Passenger validation failed for this type of flight.");

            if (passenger.Id == 0)
                await _passengerRepository.AddPassengerAsync(passenger);

            var ticket = new FlightTicketBuilder()
                .SetFlight(flight)
                .SetPassenger(passenger)
                .SetMealOption(mealOption)
                .SetSeat(seat)
                .SetEmail(userEmail)
                .Build();

            if (luggageWeight.HasValue)
                ticket.LuggageWeight = luggageWeight;

            await _ticketRepository.AddTicketAsync(ticket);
            return ticket;
        }

        public async Task<IEnumerable<Ticket>> GetAllTicketsAsync()
        {
            return await _ticketRepository.GetAllTicketsAsync();
        }
        
        public async Task<Ticket> CloneTicketAsync(int ticketId, string firstName, string lastName, string passportNumber)
        {
            var existingTicket = await _ticketRepository.GetTicketByIdAsync(ticketId);
            if (existingTicket == null)
            {
                throw new ArgumentException("Ticket not found.");
            }

            var clonedTicket = existingTicket.Clone(firstName, lastName, passportNumber);

            await _ticketRepository.AddTicketAsync(clonedTicket);
            return clonedTicket;
        }
        public async Task DeleteTicketAsync(int ticketId)
        {
            await _ticketRepository.DeleteTicketAsync(ticketId);
        }
    }
}

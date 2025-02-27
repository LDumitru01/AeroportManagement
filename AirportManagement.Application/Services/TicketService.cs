using AirportManagement.Application.Interfaces.IRepository;
using AirportManagement.Application.Interfaces.IServices;
using AirportManagement.Core.Builders;
using AirportManagement.Core.Enums;
using AirportManagement.Core.Models;

namespace AirportManagement.Application.Services
{
    public class TicketService : ITicketService
    {
        private readonly IFlightRepository _flightRepository;
        private readonly ITicketRepository _ticketRepository;
        private readonly IPassengerRepository _passengerRepository;

        public TicketService(IFlightRepository flightRepository, ITicketRepository ticketRepository, IPassengerRepository passengerRepository)
        {
            _flightRepository = flightRepository;
            _ticketRepository = ticketRepository;
            _passengerRepository = passengerRepository;
        }

        public async Task<Ticket> CreateTicketAsync(int flightId, string firstName, string lastName, string passportNumber, MealType mealOption, SeatType seat)
        {
            var flight = await _flightRepository.GetFlightByIdAsync(flightId);
            if (flight == null)
            {
                throw new ArgumentException("Flight not found.");
            }
            var existingPassenger = await _passengerRepository.GetPassengerByPassportAsync(passportNumber);

            Passenger? passenger;
            if (existingPassenger == null)
            {
                passenger = new Passenger(firstName, lastName, passportNumber);
                await _passengerRepository.AddPassengerAsync(passenger);
            }
            else
            {
                passenger = existingPassenger;
            }
            
            var ticket = new FlightTicketBuilder()
                .SetFlight(flight)
                .SetPassenger(passenger)
                .SetMealOption(mealOption)
                .SetSeat(seat)
                .Build();

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
    }
}

using AirportManagement.Application.Interfaces.IRepository;
using AirportManagement.Application.Interfaces.IServices;
using AirportManagement.Core.Builders;
using AirportManagement.Core.Enums;
using AirportManagement.Core.Models;

namespace AirportManagement.Application.Services;

public class TicketService : ITicketService
{
    private readonly IFlightRepository _flightRepository;
    private readonly ITicketRepository _ticketRepository;

    public TicketService(IFlightRepository flightRepository, ITicketRepository ticketRepository)
    {
        _flightRepository = flightRepository;
        _ticketRepository = ticketRepository;
    }

    public async Task<Ticket> CreateTicketAsync(int flightId, MealType mealOption, SeatType seat)
    {
        var flight = await _flightRepository.GetFlightByIdAsync(flightId);
        if (flight == null)
        {
            throw new ArgumentException("Flight not found.");
        }

        var ticket = new FlightTicketBuilder()
            .SetFlight(flight)
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
}
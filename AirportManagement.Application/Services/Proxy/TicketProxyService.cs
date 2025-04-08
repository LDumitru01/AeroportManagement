using AirportManagement.Application.Interfaces.IServices;
using AirportManagement.Application.Services.Session;
using AirportManagement.Core.Enums;
using AirportManagement.Core.Models;

namespace AirportManagement.Application.Services.Proxy;

public class ProxyTicketService : ITicketService
{
    private readonly ITicketService _realTicketService;

    public ProxyTicketService(ITicketService realTicketService)
    {
        _realTicketService = realTicketService;
    }

    public async Task<Ticket> CreateTicketAsync(int flightId, string firstName, string lastName, string passportNumber, MealType mealOption, SeatType seat, double? luggageWeight = null)
    {
        if (!UserSessionManager.Instance.IsLoggedIn)
            throw new UnauthorizedAccessException("User must be logged in to create a ticket.");

        return await _realTicketService.CreateTicketAsync(flightId, firstName, lastName, passportNumber, mealOption, seat, luggageWeight);
    }

    public Task<IEnumerable<Ticket>> GetAllTicketsAsync()
    {
        return _realTicketService.GetAllTicketsAsync();
    }

    public Task<Ticket> CloneTicketAsync(int ticketId, string firstName, string lastName, string passportNumber)
    {
        return _realTicketService.CloneTicketAsync(ticketId, firstName, lastName, passportNumber);
    }

    public Task DeleteTicketAsync(int ticketId)
    {
        throw new NotImplementedException();
    }
}

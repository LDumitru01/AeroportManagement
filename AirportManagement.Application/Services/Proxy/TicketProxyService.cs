using System.Security.Claims;
using AirportManagement.Application.Interfaces.IServices;
using AirportManagement.Application.Repository;
using AirportManagement.Application.Services.Session;
using AirportManagement.Core.Enums;
using AirportManagement.Core.Models;
using Microsoft.AspNetCore.Http;

namespace AirportManagement.Application.Services.Proxy;

public class ProxyTicketService : ITicketService
{
    private readonly ITicketService _realTicketService;
    private readonly TicketRepository _ticketRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public ProxyTicketService(ITicketService realTicketService, IHttpContextAccessor httpContextAccessor, TicketRepository ticketRepository)
    {
        _realTicketService = realTicketService;
        _httpContextAccessor = httpContextAccessor;
        _ticketRepository = ticketRepository;
    }

    public async Task<Ticket> CreateTicketAsync(string _, string flightNumber, string firstName, string lastName, string passportNumber, MealType mealOption, SeatType seat, double? luggageWeight = null)
    {
        var email = _httpContextAccessor?.HttpContext?.User?.Claims
            ?.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

        if (string.IsNullOrEmpty(email))
            throw new UnauthorizedAccessException("User must be logged in to create a ticket.");

        return await _realTicketService.CreateTicketAsync(
            email,
            flightNumber,
            firstName,
            lastName,
            passportNumber,
            mealOption,
            seat,
            luggageWeight
        );
    }

    public Task<IEnumerable<Ticket>> GetAllTicketsAsync()
    {
        return _realTicketService.GetAllTicketsAsync();
    }

    public Task<Ticket> CloneTicketAsync(int ticketNumber, string firstName, string lastName, string passportNumber)
    {
        return _realTicketService.CloneTicketAsync(ticketNumber, firstName, lastName, passportNumber);
    }

    public Task DeleteTicketAsync(int ticketId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Ticket>> GetTicketsByEmailAsync(string email)
    {
        var tickets = await _ticketRepository.GetTicketsByEmailAsync(email);
        return tickets;
    }
}

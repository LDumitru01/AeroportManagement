using AirportManagement.Core.Enums;
using AirportManagement.Core.Models;

namespace AirportManagement.Application.Interfaces.IServices;

public interface ITicketService
{
    Task<Ticket> CreateTicketAsync(int flightId, string firstName, string lastName, string passportNumber, MealType mealOption, SeatType seat, double? luggageWeight = null);
    Task<IEnumerable<Ticket>> GetAllTicketsAsync();
    Task<Ticket> CloneTicketAsync(int ticketId, string passportNumber, string firstName, string lastName);
    Task DeleteTicketAsync(int ticketId);
}
using AirportManagement.Core.Enums;
using AirportManagement.Core.Models;

namespace AirportManagement.Application.Interfaces.IServices;

public interface ITicketService
{
    Task<Ticket> CreateTicketAsync(string userEmail,string flightNumber, string firstName, string lastName, string passportNumber, MealType mealOption, SeatType seat, double? luggageWeight = null);
    Task<IEnumerable<Ticket>> GetAllTicketsAsync();
    Task<Ticket> CloneTicketAsync(int ticketNumber, string passportNumber, string firstName, string lastName);
    Task DeleteTicketAsync(int ticketNumber);
}
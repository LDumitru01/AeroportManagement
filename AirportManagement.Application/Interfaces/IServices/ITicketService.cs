using AirportManagement.Core.Enums;
using AirportManagement.Core.Models;

namespace AirportManagement.Application.Interfaces.IServices;

public interface ITicketService
{
    Task<Ticket> CreateTicketAsync(int flightId, MealType mealOption, SeatType seat);
    Task<IEnumerable<Ticket>> GetAllTicketsAsync();
}
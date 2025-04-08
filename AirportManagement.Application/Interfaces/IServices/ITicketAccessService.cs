using AirportManagement.Core.Enums;
using AirportManagement.Core.Models;

namespace AirportManagement.Application.Interfaces.IServices;

public interface ITicketAccessService
{
    Task<Ticket> CreateTicketAsync(int flightId, string firstName, string lastName, string passportNumber, MealType mealOption, SeatType seat);
}
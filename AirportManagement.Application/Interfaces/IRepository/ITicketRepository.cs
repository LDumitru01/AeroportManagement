using AirportManagement.Core.Models;

namespace AirportManagement.Application.Interfaces.IRepository;

public interface ITicketRepository
{
    Task AddTicketAsync(Ticket ticket);
    Task<IEnumerable<Ticket>> GetAllTicketsAsync();
    Task<Ticket?> GetTicketByIdAsync(int ticketId);
}
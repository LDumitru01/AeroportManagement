using AirportManagement.Application.Interfaces.IRepository;
using AirportManagement.Core.Models;
using AirportManagement.Database.Data;
using Microsoft.EntityFrameworkCore;

namespace AirportManagement.Application.Repository;


public class TicketRepository : ITicketRepository
{
    private readonly ApplicationDbContext _context;

    public TicketRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddTicketAsync(Ticket ticket)
    {
        await _context.Tickets.AddAsync(ticket);
        await _context.SaveChangesAsync();
    }
    

    public async Task<IEnumerable<Ticket>> GetAllTicketsAsync()
    {
        return await _context.Tickets
            .Include(t => t.Flight)
            .Include(t =>t.Passenger)
            .ToListAsync();
    }

    public async Task<Ticket?> GetTicketByIdAsync(int ticketId)
    {
        return await _context.Tickets
            .Include(t => t.Flight)
            .Include(t => t.Passenger)
            .FirstOrDefaultAsync(t => t.Id == ticketId);
    }

}
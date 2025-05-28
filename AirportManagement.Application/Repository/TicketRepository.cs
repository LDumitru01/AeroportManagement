using AirportManagement.Application.Interfaces.IRepository;
using AirportManagement.Core.Models;
using AirportManagement.Database.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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
    
    public async Task DeleteTicketAsync(int ticketId)
    {
        var ticket = await _context.Tickets.FindAsync(ticketId);
        if (ticket != null)
        {
            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateAsync(Ticket ticket)
    {
        _context.Tickets.Update(ticket);
        await _context.SaveChangesAsync();
    }
    public async Task<List<Ticket>> GetTicketsByEmailAsync(string email)
    {
        return await _context.Tickets
            .Include(t => t.Flight)
            .Where(t => t.Email == email)
            .ToListAsync();
    }
    
    public async Task<List<Ticket>> GetTicketsByFlightIdAsync(int flightId)
    {
        return await _context.Tickets
            .Where(t => t.FlightId == flightId)
            .ToListAsync();
    }
}
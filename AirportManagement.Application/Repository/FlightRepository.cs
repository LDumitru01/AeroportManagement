using AirportManagement.Application.Interfaces.IRepository;
using AirportManagement.Core.Models;
using AirportManagement.Database.Data;
using Microsoft.EntityFrameworkCore;

namespace AirportManagement.Application.Repository
{
    public class FlightRepository : IFlightRepository
    {
        private readonly ApplicationDbContext _context;

        public FlightRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Flight>> GetAllFlightsAsync()
        {
            return await _context.Flights.ToListAsync();
        }

        public async Task AddFlightAsync(Flight flight)
        {
            await _context.Flights.AddAsync(flight);
            await _context.SaveChangesAsync();
        }

        public async Task<Flight?> GetFlightByNumberAsync(string number)
        {
            return await _context.Flights.FirstOrDefaultAsync(f => f.FlightNumber == number);
        }
        
        public async Task UpdateFlightAsync(Flight flight)
        {
            _context.Flights.Update(flight);
            await _context.SaveChangesAsync();
        }
    }
}
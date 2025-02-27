using AirportManagement.Application.Interfaces.IRepository;
using AirportManagement.Core.Models;
using AirportManagement.Database.Data;
using Microsoft.EntityFrameworkCore;

namespace AirportManagement.Application.Repository;

public class PassengerRepository : IPassengerRepository
{
    private readonly ApplicationDbContext _context;

    public PassengerRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Passenger?>> GetAllPassengersAsync()
    {
        return await _context.Passengers.ToListAsync();
    }

    public async Task<Passenger?> GetPassengerByIdAsync(int id)
    {
        return await _context.Passengers.FindAsync(id);
    }

    public async Task<Passenger?> GetPassengerByPassportAsync(string passportNumber)
    {
        return await _context.Passengers.FirstOrDefaultAsync(p => p.PassportNumber == passportNumber);
    }

    public async Task AddPassengerAsync(Passenger? passenger)
    {
        await _context.Passengers.AddAsync(passenger);
        await _context.SaveChangesAsync();
    }
}

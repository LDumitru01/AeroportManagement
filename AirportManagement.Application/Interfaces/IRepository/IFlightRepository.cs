using AirportManagement.Core.Models;

namespace AirportManagement.Application.Interfaces.IRepository;

public interface IFlightRepository
{
    Task<List<Flight>> GetAllFlightsAsync();
    Task AddFlightAsync(Flight flight);
    Task<Flight?> GetFlightByIdAsync(int id);
    Task UpdateFlightAsync(Flight flight);
}
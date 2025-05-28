using AirportManagement.Core.Models;

namespace AirportManagement.Application.Interfaces.IRepository;

public interface IFlightRepository
{
    Task<List<Flight>> GetAllFlightsAsync();
    Task AddFlightAsync(Flight flight);
    Task<Flight?> GetFlightByNumberAsync(string number);
    Task UpdateFlightAsync(Flight flight);
}
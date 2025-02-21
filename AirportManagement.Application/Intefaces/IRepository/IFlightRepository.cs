using AirportManagement.Core.Models;

namespace AirportManagement.Application.Intefaces.IRepository;

public interface IFlightRepository
{
    Task<List<Flight>> GetAllFlightsAsync();
    Task AddFlightAsync(Flight flight);
    Task<Flight?> GetFlightByIdAsync(int id);
}
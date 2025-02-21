using AirportManagement.Core.Models;

namespace AirportManagement.Application.Intefaces.IServices
{
    public interface IFlightService
    {
        Task AddFlightAsync(Flight flight);
        Task<List<Flight>> GetFlightsAsync();
        Task<Flight?> GetFlightByIdAsync(int id);
    }
}
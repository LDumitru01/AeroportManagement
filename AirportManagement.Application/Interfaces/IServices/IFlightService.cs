using AirportManagement.Core.Models;

namespace AirportManagement.Application.Interfaces.IServices
{
    public interface IFlightService
    {
        Task<IEnumerable<Flight>> GetFlightsAsync();
        Task<Flight> AddFlightAsync(Flight flight);
        Task<IEnumerable<Flight>> GetAvailableFlightsAsync();
        Task<Flight> GetFlightByIdAsync(int requestFlightId);
    }
}
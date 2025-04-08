using AirportManagement.Core.Enums;
using AirportManagement.Core.Models;

namespace AirportManagement.Application.Interfaces.IServices
{
    public interface IFlightService
    {
        Task<IEnumerable<Flight>> GetFlightsAsync();
        Task<Flight> AddFlightAsync(Flight flight);
        Task<IEnumerable<Flight>> GetAvailableFlightsAsync();
        Task<Flight?> GetFlightByIdAsync(int requestFlightId);
        Task UpdateFlightAsync(Flight flight);
        Task UpdateFlightStatusAsync(int flightId, FlightStatus newStatus);
        Task SaveFlightStateAsync(int flightId);
        Task RestoreFlightStateAsync(int flightId);
    }
}
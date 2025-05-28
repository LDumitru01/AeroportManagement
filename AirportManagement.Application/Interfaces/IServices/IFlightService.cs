using AirportManagement.Core.Enums;
using AirportManagement.Core.Models;

namespace AirportManagement.Application.Interfaces.IServices
{
    public interface IFlightService
    {
        Task<IEnumerable<Flight>> GetFlightsAsync();
        Task<Flight> AddFlightAsync(Flight flight);
        Task<IEnumerable<Flight>> GetAvailableFlightsAsync();
        Task<Flight?> GetFlightByNumberAsync(string flightNumber);
        Task UpdateFlightAsync(Flight flight);
        Task UpdateFlightStatusAsync(string flightNumber, FlightStatus newStatus);
        Task SaveFlightStateAsync(string flightNumber);
        Task RestoreFlightStateAsync(string flightNumber);
    }
}
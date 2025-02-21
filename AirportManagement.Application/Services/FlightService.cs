using AirportManagement.Application.Intefaces.IRepository;
using AirportManagement.Application.Intefaces.IServices;
using AirportManagement.Core.Models;

namespace AirportManagement.Application.Services
{
    public class FlightService : IFlightService
    {
        private readonly IFlightRepository _flightRepository;

        public FlightService(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
        }

        public async Task AddFlightAsync(Flight flight)
        {
            // 🚀 Validare: Zborul nu trebuie să fie în trecut
            if (flight.DepartureTime < DateTime.Now)
            {
                throw new Exception("connot add a past flight");
            }

            await _flightRepository.AddFlightAsync(flight);
        }

        public async Task<List<Flight>> GetFlightsAsync()
        {
            return await _flightRepository.GetAllFlightsAsync();
        }

        public async Task<Flight?> GetFlightByIdAsync(int id)
        {
            return await _flightRepository.GetFlightByIdAsync(id);
        }
    }
}
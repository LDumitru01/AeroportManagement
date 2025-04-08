using AirportManagement.Application.Interfaces.IRepository;
using AirportManagement.Application.Interfaces.IServices;
using AirportManagement.Core.Enums;
using AirportManagement.Core.Memento;
using AirportManagement.Core.Models;
using AirportManagement.Core.Observer;

namespace AirportManagement.Application.Services
{
    public class FlightService : IFlightService
    {
        private readonly  IFlightRepository _flightRepository;
        private FlightHistoryManager _flightHistoryManager;

        public FlightService(IFlightRepository flightRepository, FlightHistoryManager flightHistoryManager)
        {
            _flightRepository = flightRepository;
            _flightHistoryManager = flightHistoryManager;
        }

        public async Task<IEnumerable<Flight>> GetFlightsAsync()
        {
            return await _flightRepository.GetAllFlightsAsync();
        }

        public async Task<Flight> AddFlightAsync(Flight flight)
        {
            await _flightRepository.AddFlightAsync(flight);
            return flight;
        }
        
        public async Task<Flight?> GetFlightByIdAsync(int id)
        {
            return await _flightRepository.GetFlightByIdAsync(id);
        }
        public async Task UpdateFlightAsync(Flight flight)
        {
            await _flightRepository.UpdateFlightAsync(flight);
        }

        public async Task<IEnumerable<Flight>> GetAvailableFlightsAsync()
        {
            var allFlights = await _flightRepository.GetAllFlightsAsync();
            return allFlights.Where(f => f.Status == FlightStatus.Scheduled);
        }
        
        public async Task UpdateFlightStatusAsync(int flightId, FlightStatus newStatus)
        {
            var flight = await _flightRepository.GetFlightByIdAsync(flightId);
            if (flight == null)
                throw new Exception("Flight not found");

            var subject = new FlightSubject(flight);
            subject.Attach(new EmailNotificationObserver());
            subject.Attach(new SmsNotificationObserver());
            var manager = new FlightStateManager(flight);
            _flightHistoryManager.SaveState(manager); 

            flight.Status = newStatus;
            await _flightRepository.UpdateFlightAsync(flight); 

            subject.Notify(newStatus.ToString()); 
        }
        
        public async Task SaveFlightStateAsync(int flightId)
        {
            var flight = await _flightRepository.GetFlightByIdAsync(flightId);
            if (flight == null) throw new Exception("Flight not found");

            var manager = new FlightStateManager(flight);
            _flightHistoryManager.SaveState(manager);
        }

        public async Task RestoreFlightStateAsync(int flightId)
        {
            var memento = _flightHistoryManager.RestoreLastState();
            if (memento == null) throw new Exception("No saved state");

            var flight = await _flightRepository.GetFlightByIdAsync(flightId);
            if (flight == null) throw new Exception("Flight not found");

            flight.FlightNumber = memento.FlightNumber;
            flight.Destination = memento.Destination;
            flight.DepartureTime = memento.DepartureTime;
            flight.Status = memento.Status;

            await _flightRepository.UpdateFlightAsync(flight);
        }

    }
}
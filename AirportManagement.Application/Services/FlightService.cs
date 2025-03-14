﻿using AirportManagement.Application.Interfaces.IRepository;
using AirportManagement.Application.Interfaces.IServices;
using AirportManagement.Core.Enums;
using AirportManagement.Core.Models;

namespace AirportManagement.Application.Services
{
    public class FlightService : IFlightService
    {
        private readonly  IFlightRepository _flightRepository;
        private IFlightService _flightServiceImplementation;

        public FlightService(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository;
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

        public async Task<IEnumerable<Flight>> GetAvailableFlightsAsync()
        {
            var allFlights = await _flightRepository.GetAllFlightsAsync();
            return allFlights.Where(f => f.Status == FlightStatus.Scheduled);
        }
    }
}
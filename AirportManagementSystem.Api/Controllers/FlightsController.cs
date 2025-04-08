using AirportManagement.Application.Interfaces.IServices;
using AirportManagement.Core.Iterator;
using AirportManagement.Core.Memento;
using AirportManagement.Core.Models;
using AirportManagement.Core.Observer;
using Microsoft.AspNetCore.Mvc;

namespace AirportManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightService _flightService;
        private readonly FlightHistoryManager _flightHistoryManager;

        public FlightsController(IFlightService flightService, FlightHistoryManager flightHistoryManager)
        {
            _flightService = flightService;
            _flightHistoryManager = flightHistoryManager;
        }

        [HttpPatch("set-international/{id}")]
        public async Task<IActionResult> SetInternational(int id, [FromQuery] bool isInternational)
        {
            var flight = await _flightService.GetFlightByIdAsync(id);
            if (flight == null)
                return NotFound("Flight not found");

            flight.IsInternational = isInternational;
            await _flightService.UpdateFlightAsync(flight);

            return Ok(new { Message = $"Flight {id} updated with IsInternational = {isInternational}" });
        }

        [HttpGet]
        public async Task<IActionResult> GetFlights()
        {
            var flights = await _flightService.GetFlightsAsync();
            return Ok(flights);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Flight flight)
        {
            var createdFlight = await _flightService.AddFlightAsync(flight);
            return Created($"api/Flights/{createdFlight.Id}", createdFlight);
        }

        [HttpGet("available")]
        public async Task<IActionResult> GetAvailableFlights()
        {
            var availableFlights = await _flightService.GetAvailableFlightsAsync();
            return Ok(availableFlights);
        }

        [HttpPut("update-status")]
        public async Task<IActionResult> UpdateFlightStatus([FromBody] UpdateFlightStatusRequest request)
        {
            var flight = await _flightService.GetFlightByIdAsync(request.FlightId);
            if (flight == null)
                return NotFound("Flight not found.");

            var manager = new FlightStateManager(flight);
            _flightHistoryManager.SaveState(manager);

            flight.Status = request.NewStatus;
            await _flightService.UpdateFlightAsync(flight);

            return Ok($"Flight status updated to {request.NewStatus}");
        }

        [HttpPost("restore")]
        public async Task<IActionResult> RestoreLastFlightState()
        {
            var memento = _flightHistoryManager.RestoreLastState();
            if (memento == null)
                return BadRequest("No saved state to restore.");

            var flight = await _flightService.GetFlightByIdAsync(memento.Id);
            if (flight == null)
                return NotFound("Flight not found.");

            var manager = new FlightStateManager(flight);
            manager.RestoreState(memento);

            await _flightService.UpdateFlightAsync(manager.GetFlight());

            return Ok("Flight restored to previous state.");
        }
        
        [HttpGet("iterate")]
        public async Task<IActionResult> IterateFlights()
        {
            var allFlights = await _flightService.GetFlightsAsync();
            var flightCollection = new FlightCollection();

            foreach (var flight in allFlights)
            {
                flightCollection.AddFlight(flight);
            }

            var iterator = flightCollection.CreateIterator();
            var result = new List<string>();

            while (iterator.HasNext())
            {
                var f = iterator.Next();
                result.Add($"Flight: {f.FlightNumber} to {f.Destination} at {f.DepartureTime}");
            }

            return Ok(result);
        }
    }
}    
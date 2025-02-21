using AirportManagement.Application.Interfaces.IServices;
using AirportManagement.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirportManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightService _flightService;

        public FlightsController(IFlightService flightService)
        {
            _flightService = flightService;
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
    }
}
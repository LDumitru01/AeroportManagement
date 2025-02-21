using AirportManagement.Application.Intefaces.IServices;
using Microsoft.AspNetCore.Mvc; // 📌 Importăm namespace-ul unde se află ControllerBase

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
    }
}
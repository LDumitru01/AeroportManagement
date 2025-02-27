using AirportManagement.Application.Interfaces.IServices;
using AirportManagement.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirportManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateTicket([FromBody] CreateTicketRequest request)
        {
            var ticket = await _ticketService.CreateTicketAsync(
                request.FlightId,
                request.FirstName,
                request.LastName,
                request.PassportNumber,
                request.MealOption,
                request.Seat
            );

            return Ok(ticket);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllTickets()
        {
            var tickets = await _ticketService.GetAllTicketsAsync();
            return Ok(tickets);
        }
        
        [HttpPost("clone/{ticketId}")]
        public async Task<IActionResult> CloneTicket(int ticketId, [FromBody] CloneTicketRequest request)
        {
            var clonedTicket = await _ticketService.CloneTicketAsync(ticketId, request.FirstName, request.LastName, request.PassportNumber);
            return Ok(clonedTicket);
        }
    }
}
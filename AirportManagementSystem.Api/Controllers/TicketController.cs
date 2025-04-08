using AirportManagement.Application.Command;
using AirportManagement.Application.Interfaces.IServices;
using AirportManagement.Application.Services.Proxy;
using AirportManagement.Core.Decorator;
using AirportManagement.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirportManagementSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ProxyTicketService _ticketService;

        public TicketController(ProxyTicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateTicket([FromBody] CreateTicketRequest request)
        {
            try
            {
                var ticket = await _ticketService.CreateTicketAsync(
                    request.FlightId,
                    request.FirstName,
                    request.LastName,
                    request.PassportNumber,
                    request.MealOption,
                    request.Seat,
                    request.LuggageWeight
                );

                ITicketComponent ticketComponent = ticket;
                if (request.LuggageWeight.HasValue && request.LuggageWeight.Value > 0)
                {
                    ticketComponent = new LuggageDecorator(ticketComponent, request.LuggageWeight.Value);
                }

                return Ok(new { Info = ticketComponent.GetTicketInfo() });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { Error = ex.Message });
            }
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
        
        [HttpPost("command/create")]
        public async Task<IActionResult> ExecuteTicketCommand([FromBody] CreateTicketRequest request)
        {
            var command = new CreateTicketCommand(
                _ticketService,
                request.FlightId,
                request.FirstName,
                request.LastName,
                request.PassportNumber,
                request.MealOption,
                request.Seat,
                request.LuggageWeight
            );

            var invoker = new CommandInvoker();
            await invoker.ExecuteCommandAsync(command);

            return Ok("Ticket created with command.");
        }
    }
}
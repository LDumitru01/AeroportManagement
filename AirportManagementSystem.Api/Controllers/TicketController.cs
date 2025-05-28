using System.Security.Claims;
using AirportManagement.Application.ChainOfResposibilityApp;
using AirportManagement.Application.Command;
using AirportManagement.Application.Interfaces.IServices;
using AirportManagement.Application.Repository;
using AirportManagement.Application.Services.Proxy;
using AirportManagement.Core.Decorator;
using AirportManagement.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AirportManagementSystem.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ProxyTicketService _ticketService;
        private readonly SeatAvailabilityHandler _seatHandler;
        private readonly PassengerValidationHandler _passengerHandler;
        private readonly LuggageValidationHandler _luggageHandler;
        private readonly TicketRepository _ticketRepository;

        public TicketController(ProxyTicketService ticketService, SeatAvailabilityHandler seatHandler, PassengerValidationHandler passengerHandler, LuggageValidationHandler luggageHandler, TicketRepository ticketRepository)
        {
            _ticketService = ticketService;
            _seatHandler = seatHandler;
            _passengerHandler = passengerHandler;
            _luggageHandler = luggageHandler;
            _ticketRepository = ticketRepository;
        }
        [Authorize]
        [HttpPost("create")]
        public async Task<IActionResult> CreateTicket([FromBody] CreateTicketRequest request)
        {
            _seatHandler.SetNext(_passengerHandler);
            _passengerHandler.SetNext(_luggageHandler);

            await _seatHandler.HandleAsync(request);

            try
            {
                // ✅ Obține emailul din token
                var userEmail = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value;
                if (string.IsNullOrEmpty(userEmail))
                    return Unauthorized(new { Error = "Utilizatorul nu este autentificat." });

                var ticket = await _ticketService.CreateTicketAsync(
                    userEmail,
                    request.FlightNumber,
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
        
        [Authorize]
        [HttpGet("reserved")]
        public async Task<IActionResult> GetReservedTickets()
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value 
                        ?? User.FindFirst("email")?.Value;

            if (string.IsNullOrEmpty(email))
                return Unauthorized("Utilizatorul nu este autentificat.");

            var tickets = await _ticketService.GetTicketsByEmailAsync(email);
            return Ok(tickets);
        }

        
        [HttpPost("clone/{ticketId}")]
        public async Task<IActionResult> CloneTicket(int ticketNumber, [FromBody] CloneTicketRequest request)
        {
            var clonedTicket = await _ticketService.CloneTicketAsync(ticketNumber, request.FirstName, request.LastName, request.PassportNumber);
            return Ok(clonedTicket);
        }
        
        
        [Authorize]
        [HttpPost("command/create")]
        public async Task<IActionResult> ExecuteTicketCommand([FromBody] CreateTicketRequest request)
        {
            var userEmail = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value;
            if (string.IsNullOrEmpty(userEmail))
                return Unauthorized(new { Error = "Utilizatorul nu este autentificat." });
                
            var command = new CreateTicketCommand(
                _ticketService,
                userEmail,
                request.FlightNumber,
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
        
        [HttpGet("user-tickets")]
        public async Task<IActionResult> GetTicketsByUserEmail([FromQuery] string email)
        {
            var tickets = await _ticketRepository.GetTicketsByEmailAsync(email);
            return Ok(tickets);
        }
    }
}
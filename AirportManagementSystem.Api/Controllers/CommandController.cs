using AirportManagement.Application.Command;
using AirportManagement.Application.Interfaces.IServices;
using AirportManagement.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirportManagementSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CommandController : ControllerBase
{
    private readonly ICommandInvoker _invoker;
    private readonly ITicketService _ticketService;

    public CommandController(ICommandInvoker invoker, ITicketService ticketService)
    {
        _invoker = invoker;
        _ticketService = ticketService;
    }

    [HttpPost("create-ticket")]
    public async Task<IActionResult> CreateTicketWithCommand([FromBody] CreateTicketRequest request)
    {
        var command = new CreateTicketCommand(
            _ticketService,
            request.FlightId,
            request.FirstName,
            request.LastName,
            request.PassportNumber,
            request.MealOption,
            request.Seat,
            request.LuggageWeight);

        await _invoker.ExecuteCommandAsync(command);

        return Ok("Ticket created via Command pattern.");
    }

    [HttpPost("undo-last")]
    public async Task<IActionResult> UndoLastCommand()
    {
        await _invoker.UndoLastCommandAsync();
        return Ok("Undo performed.");
    }
}

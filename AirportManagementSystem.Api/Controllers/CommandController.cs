using AirportManagement.Application.Command;
using AirportManagement.Application.Interfaces.IServices;
using AirportManagement.Core.Models;
using Microsoft.AspNetCore.Authorization;
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
    
    [Authorize] // Asigură-te că ești autentificat
    [HttpPost("create-ticket")]
    public async Task<IActionResult> CreateTicketWithCommand([FromBody] CreateTicketRequest request)
    {
        // 1. Obține emailul utilizatorului logat din tokenul JWT
        var userEmail = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value;

        // 2. Verifică dacă este null (adică tokenul e invalid sau lipsește)
        if (string.IsNullOrEmpty(userEmail))
            return Unauthorized("Utilizatorul nu este autentificat.");

        // 3. Creează comanda
        var command = new CreateTicketCommand(
            _ticketService,
            userEmail,                          // <-- emailul utilizatorului logat
            request.FlightNumber,
            request.FirstName,
            request.LastName,
            request.PassportNumber,
            request.MealOption,
            request.Seat,
            request.LuggageWeight);

        // 4. Execută comanda
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

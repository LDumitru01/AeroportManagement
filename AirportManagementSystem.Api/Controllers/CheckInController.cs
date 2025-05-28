using AirportManagement.Application.Models;
using AirportManagement.Application.Repository;
using AirportManagement.Core.Enums;
using AirportManagement.Core.TemplateMethod;
using Microsoft.AspNetCore.Mvc;

namespace AirportManagementSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CheckInController : ControllerBase
{
    private readonly TicketRepository _ticketRepository;

    public CheckInController(TicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    [HttpPost("economy")]
    public IActionResult EconomyCheckIn()
    {
        var checkIn = new EconomyCheckInProcess();
        checkIn.CheckIn();
        return Ok("Economy check-in completed.");
    }

    [HttpPost("business")]
    public IActionResult BusinessCheckIn()
    {
        var checkIn = new BusinessCheckInProcess();
        checkIn.CheckIn();
        return Ok("Business check-in completed.");
    }

    [HttpPost("vip")]
    public IActionResult VipCheckIn()
    {
        var checkIn = new VipCheckInProcess();
        checkIn.CheckIn();
        return Ok("VIP check-in completed.");
    }
    
    [HttpPost("perform")]
    public async Task<IActionResult> PerformCheckIn([FromBody] CheckInRequestDto dto)
    {
        var ticket = await _ticketRepository.GetTicketByIdAsync(dto.TicketId);
        if (ticket == null)
            return NotFound("Biletul nu a fost găsit.");

        if (ticket.IsCheckedIn)
            return BadRequest("Biletul a fost deja procesat.");

        CheckInProcess checkInProcess = dto.Type switch
        {
            CheckInType.Standard => new EconomyCheckInProcess(),
            CheckInType.Business => new BusinessCheckInProcess(),
            CheckInType.VIP => new VipCheckInProcess(),
            _ => throw new ArgumentException("Tip invalid de check-in")
        };

        checkInProcess.CheckIn();

        ticket.IsCheckedIn = true;
        ticket.CheckInType = dto.Type.ToString(); // salvezi ca string sau ca enum
        await _ticketRepository.UpdateAsync(ticket);

        return Ok($"Check-in complet pentru {dto.Type}");
    }
    
    [HttpGet("flight-checkins/{flightId}")]
    public async Task<IActionResult> GetCheckInsByFlightId(int flightId)
    {
        var checkins = await _ticketRepository.GetTicketsByFlightIdAsync(flightId); // ATENȚIE: metodă plurală care returnează o listă

        var result = checkins
            .Where(t => t.IsCheckedIn)
            .Select(t => new
            {
                t.Id,
                t.Email,
                t.Seat,
                t.MealOption,
                t.CheckInType,
                t.PassportType,
                t.DateOfBirth
            });

        return Ok(result);
    }


}
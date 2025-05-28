using AirportManagement.Core.Mediator;
using Microsoft.AspNetCore.Mvc;

namespace AirportManagementSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmergencyController : ControllerBase
{
    private readonly IMediator _mediator;

    public EmergencyController(IMediator mediator)
    {
        _mediator = mediator;
        _mediator.RegisterParticipant(new PilotEmergencyParticipant("Captain John"));
        _mediator.RegisterParticipant(new CrewEmergencyParticipant("Crew A"));
        _mediator.RegisterParticipant(new AirTrafficControlParticipant("Control Tower 1"));
    }

    [HttpPost("trigger")]
    public IActionResult TriggerEmergency([FromQuery] string message)
    {
        _mediator.NotifyParticipants(message);
        return Ok($"Emergency message '{message}' sent to all participants.");
    }
}
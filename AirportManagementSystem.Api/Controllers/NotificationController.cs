using AirportManagement.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace AirportManagementSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotificationController : ControllerBase
{
    private readonly INotificationService _notificationService;

    public NotificationController(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    [HttpPost("flight")]
    public IActionResult SendFlightNotification([FromQuery] string to, [FromQuery] string message, [FromQuery] bool useEmail = true)
    {
        _notificationService.NotifyFlightChange(to, message, useEmail);
        return Ok("Notification sent");
    }
}
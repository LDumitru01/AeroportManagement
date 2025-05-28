using AirportManagement.Core.Bridge;
using Microsoft.AspNetCore.Mvc;

namespace AirportManagementSystem.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotificationsController : ControllerBase
{
    [HttpPost("send")]
    public async Task<IActionResult> Send([FromBody] SendMessageRequest request)
    {
        var sender = new EmailNotificationSender();
        var notification = new FlightNotification(sender);

        await notification.NotifyAsync(request.Destination, request.Message);
        return Ok();
    }
}

public class SendMessageRequest
{
    public SendMessageRequest(string destination, string message)
    {
        Destination = destination;
        Message = message;
    }

    public string Destination { get; set; }
    public string Message { get; set; }
}
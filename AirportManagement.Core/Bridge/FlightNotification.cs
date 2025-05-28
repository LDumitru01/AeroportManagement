namespace AirportManagement.Core.Bridge;

public class FlightNotification : Notification
{
    public FlightNotification(INotificationSender sender) : base(sender) {}

    public override async Task NotifyAsync(string destination, string content)
    {
        await _sender.SendAsync(destination, content);
    }
}
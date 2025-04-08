namespace AirportManagement.Core.Bridge;

public class FlightNotification : Notification
{
    public FlightNotification(INotificationSender sender) : base(sender)
    {
    }

    public override void Notify(string to, string message)
    {
        _sender.Send(to, $"[FLight info] {message}");
    }
}
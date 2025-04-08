namespace AirportManagement.Core.Bridge;

public abstract class Notification
{
    protected readonly INotificationSender _sender;

    protected Notification(INotificationSender sender)
    {
        _sender = sender;
    }
    
    public abstract void Notify(string to, string message);
}
namespace AirportManagement.Core.Bridge;

public interface INotificationSender
{
    public Task SendAsync (string to, string message);
}
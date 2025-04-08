namespace AirportManagement.Core.Bridge;

public interface INotificationSender
{
    void Send (string to, string message);
}
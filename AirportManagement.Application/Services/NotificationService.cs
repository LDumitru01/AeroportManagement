using AirportManagement.Application.Interfaces.IServices;
using AirportManagement.Core.Bridge;

namespace AirportManagement.Application.Services;

public class NotificationService : INotificationService
{
    public void NotifyFlightChange(string userContact, string message, bool useEmail)
    {
        INotificationSender sender = useEmail
            ? new EmailNotificationSender()
            : new SmsNotificationSender();

        var notification = new FlightNotification(sender);
        notification.Notify(userContact, message);
    }
}
namespace AirportManagement.Application.Interfaces.IServices;

public interface INotificationService
{
    void NotifyFlightChange(string userContact, string message, bool useEmail);
}
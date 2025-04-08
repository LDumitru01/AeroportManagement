namespace AirportManagement.Core.Observer;

public interface IObserver
{
    void Update(string flightNumber, string status);
}
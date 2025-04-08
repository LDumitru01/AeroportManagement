using AirportManagement.Core.Models;

namespace AirportManagement.Core.Observer;

public class FlightSubject : ISubject
{
    private readonly List<IObserver> _observers = new();
    private readonly Flight _flight;

    public FlightSubject(Flight flight)
    {
        _flight = flight;
    }

    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify(string status)
    {
        foreach (var observer in _observers)
        {
            observer.Update(_flight.FlightNumber, status);
        }
    }
}
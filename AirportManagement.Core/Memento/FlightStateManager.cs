using AirportManagement.Core.Models;

namespace AirportManagement.Core.Memento;

public class FlightStateManager
{
    private Flight _flight;

    public FlightStateManager(Flight flight)
    {
        _flight = flight;
    }

    public FlightMemento SaveState()
    {
        return new FlightMemento(_flight.Status, _flight.DepartureTime, _flight.FlightNumber, _flight.Destination, _flight.Id);
    }

    public void RestoreState(FlightMemento memento)
    {
        _flight.FlightNumber = memento.FlightNumber;
        _flight.Destination = memento.Destination;
        _flight.DepartureTime = memento.DepartureTime;
        _flight.Status = memento.Status;
    }

    public Flight GetFlight() => _flight;
}
using AirportManagement.Core.Models;

namespace AirportManagement.Core.Iterator;

public class FlightCollection : IAgregate<Flight>
{
    private readonly List<Flight> _flights = new();

    public void AddFlight(Flight flight)
    {
        _flights.Add(flight);
    }

    public List<Flight> GetAll() => _flights;
    
    public IIterator<Flight> CreateIterator()
    {
        return new FlightIterator(_flights);
    }
}
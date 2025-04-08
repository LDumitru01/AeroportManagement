using AirportManagement.Core.Models;

namespace AirportManagement.Core.Iterator;

public class FlightIterator : IIterator<Flight>
{
    private readonly List<Flight> _flights;
    public int Position = 0;

    public FlightIterator(List<Flight> flights)
    {
        _flights = flights;
    }

    public bool HasNext()
    {
        return Position < _flights.Count;
    }

    public Flight Next()
    {
        return _flights[Position++];
    }
}
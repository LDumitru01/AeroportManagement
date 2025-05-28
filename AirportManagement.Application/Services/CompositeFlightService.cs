using AirportManagement.Application.Interfaces.IRepository;
using AirportManagement.Application.Interfaces.IServices;
using AirportManagement.Core.CompositePattern;

namespace AirportManagement.Application.Services;

public class CompositeFlightService : ICompositeFlightService
{
    private readonly IFlightRepository _flightRepository;

    public CompositeFlightService(IFlightRepository flightRepository)
    {
        _flightRepository = flightRepository;
    }

    public async Task<IFlightComponent> BuildCompositeFlightAsync(List<string> flightNumbers)
    {
        var composite = new CompositeFlight();

        foreach (var number in flightNumbers)
        {
            var flight = await _flightRepository.GetFlightByNumberAsync(number);
            if (flight != null)
            {
                var flightLeaf = new FlightLeaf(flight);
                composite.Add(flightLeaf);
            }
        }

        return composite;
    }
}

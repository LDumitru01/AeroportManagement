using AirportManagement.Core.Models;

namespace AirportManagement.Core.Strategy;

public class PassengerValidationStrategySelector : IPassengerValidationStrategySelector
{
    private readonly IPassengerValidationStrategy _domesticStrategy;
    private readonly IPassengerValidationStrategy _internationalStrategy;

    public PassengerValidationStrategySelector(
        DomesticFlightValidationStrategy domesticStrategy,
        InternationalFlightValidationStrategy internationalStrategy)
    {
        _domesticStrategy = domesticStrategy;
        _internationalStrategy = internationalStrategy;
    }

    public IPassengerValidationStrategy SelectStrategy(Flight flight)
    {
        return flight.IsInternational ? _internationalStrategy : _domesticStrategy;
    }
}
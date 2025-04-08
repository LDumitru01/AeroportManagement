using AirportManagement.Core.Models;

namespace AirportManagement.Core.Strategy;

public interface IPassengerValidationStrategySelector
{
    IPassengerValidationStrategy SelectStrategy(Flight flight);
}
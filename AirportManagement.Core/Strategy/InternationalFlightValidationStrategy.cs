using AirportManagement.Core.Models;

namespace AirportManagement.Core.Strategy;

public class InternationalFlightValidationStrategy : IPassengerValidationStrategy
{
    public Task<bool> ValidatePassengerAsync(Passenger passenger, Flight flight)
    {
        if (string.IsNullOrEmpty(passenger.PassportNumber) || passenger.PassportNumber.Length < 6)
        {
            return Task.FromResult(false);
        }

        return Task.FromResult(true);
    }
}
using AirportManagement.Core.Interfaces;
using AirportManagement.Core.Models.ReservationType;

namespace AirportManagement.Core.Factories;

public static class ReservationFactories
{
    public static IReservation CreateReservation(string type)
    {
        return type switch
        {
            "Economic" => new EconomicReservation(),
            "Business" => new BusinessReservation(),
            "FirstClass" => new FirstClassReservation(),
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }
}
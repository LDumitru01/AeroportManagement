using AirportManagement.Core.Interfaces;
using AirportManagement.Core.Models.ReservationType;

namespace AirportManagement.Core.Factories;

public class FirstClassReservationFactory : IReservationFactory
{
    public IReservation CreateReservation()
    {
        return new FirstClassReservation();
    }
}
using AirportManagement.Core.Interfaces;
using AirportManagement.Core.Models.ReservationType;

namespace AirportManagement.Core.Factories;

public class BusinessReservationFactory : IReservationFactory
{
    public IReservation CreateReservation()
    {
        return new BusinessReservation();
    }
}
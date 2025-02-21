using AirportManagement.Core.Interfaces;

namespace AirportManagement.Core.Models.ReservationType;

public class FirstClassReservation : IReservation
{
    public string GetReservationDetails()
    {
        return "FirstClass";
    }
}
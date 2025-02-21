using AirportManagement.Core.Interfaces;

namespace AirportManagement.Core.Models.ReservationType;

public class BusinessReservation : IReservation
{
    public string GetReservationDetails()
    {
        return "Business Reservation";
    }
}
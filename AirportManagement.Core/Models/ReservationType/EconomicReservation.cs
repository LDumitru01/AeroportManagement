using AirportManagement.Core.Interfaces;

namespace AirportManagement.Core.Models.ReservationType;

public class EconomicReservation : IReservation
{
    public string GetReservationDetails()
    {
        return "Economic Reservation";
    }
}
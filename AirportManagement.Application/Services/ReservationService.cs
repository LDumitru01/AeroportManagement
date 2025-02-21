using AirportManagement.Application.Interfaces.IServices;
using AirportManagement.Core.Factories;
using AirportManagement.Core.Interfaces;

namespace AirportManagement.Application.Services;

public class ReservationService : IReservationService
{
    public IReservation CreateReservation(string type)
    {
        return ReservationFactories.CreateReservation(type);
    }
}
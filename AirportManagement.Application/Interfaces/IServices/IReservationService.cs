using AirportManagement.Core.Interfaces;

namespace AirportManagement.Application.Interfaces.IServices;

public interface IReservationService
{
    IReservation CreateReservation(string type);
}
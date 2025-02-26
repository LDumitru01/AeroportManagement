using AirportManagement.Core.Models;

namespace AirportManagement.Application.Interfaces.IRepository;

public interface IReservationRepository
{
    Task AddReservationAsync(Reservation reservation);
    Task<IEnumerable<Reservation>> GetAllReservationsAsync();
}
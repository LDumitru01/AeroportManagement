using AirportManagement.Application.Interfaces.IRepository;
using AirportManagement.Core.Models;

namespace AirportManagement.Application.Repository;

public class ReservationRepository : IReservationRepository
{
    public Task AddReservationAsync(Reservation reservation)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Reservation>> GetAllReservationsAsync()
    {
        throw new NotImplementedException();
    }
}
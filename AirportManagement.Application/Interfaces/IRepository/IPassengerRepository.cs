using AirportManagement.Core.Models;

namespace AirportManagement.Application.Interfaces.IRepository;

public interface IPassengerRepository
{
    Task<IEnumerable<Passenger?>> GetAllPassengersAsync();
    Task<Passenger?> GetPassengerByIdAsync(int id);
    Task<Passenger?> GetPassengerByPassportAsync(string passportNumber);
    Task AddPassengerAsync(Passenger? passenger);
}
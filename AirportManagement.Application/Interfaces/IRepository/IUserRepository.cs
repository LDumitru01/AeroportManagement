using AirportManagement.Core.Models;
using AirportManagement.Core.Models.Auth;

namespace AirportManagement.Application.Interfaces.IRepository;

public interface IUserRepository
{
    Task<User?> GetUserByEmailAsync(string email);
    Task AddUserAsync(User user);
    Task<User?> GetUserByIdAsync(int userId);
}
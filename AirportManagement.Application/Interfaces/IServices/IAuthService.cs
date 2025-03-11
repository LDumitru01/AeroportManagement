using AirportManagement.Core.Authentification;
using AirportManagement.Core.Models;
using AirportManagement.Core.Models.Auth;

namespace AirportManagement.Application.Interfaces.IServices;

public interface IAuthService
{
    Task<User?> RegisterUserAsync(RegisterUserRequest request);
    Task<User?> LoginAsync(string email, string password);
}
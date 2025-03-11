using System.Security.Cryptography;
using System.Text;
using AirportManagement.Application.Interfaces.IRepository;
using AirportManagement.Application.Interfaces.IServices;
using AirportManagement.Application.Services.Cahce;
using AirportManagement.Core.Models.Auth;

namespace AirportManagement.Application.Services;

public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserCacheService _cacheService;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _cacheService = UserCacheService.GetInstance(userRepository);
        }

        public async Task<User?> RegisterUserAsync(RegisterUserRequest request)
        {
            var existingUser = await _userRepository.GetUserByEmailAsync(request.Email);
            if (existingUser != null)
            {
                throw new ArgumentException("Email already in use.");
            }

            string hashedPassword = HashPassword(request.Password);

            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PasswordHash = hashedPassword
            };

            await _userRepository.AddUserAsync(user);
            
            _cacheService.AddUserToCache(user);

            return user;
        }

        public async Task<User?> LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            if (user == null || !VerifyPassword(password, user.PasswordHash))
            {
                return null;
            }

            return user;
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        private bool VerifyPassword(string password, string hashedPassword)
        {
            return HashPassword(password) == hashedPassword;
        }
    }
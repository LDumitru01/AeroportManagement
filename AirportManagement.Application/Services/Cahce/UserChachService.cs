using System.Collections.Concurrent;
using System.Timers;
using AirportManagement.Application.Interfaces.IRepository;
using AirportManagement.Core.Models.Auth;
using Timer = System.Threading.Timer;


namespace AirportManagement.Application.Services.Cahce;

public class UserCacheService
    {
        private static UserCacheService? _instance;
        private static readonly object _lock = new();
        
        private readonly ConcurrentDictionary<int, User> _cache;
        private readonly IUserRepository _userRepository;
        private readonly Timer _cacheExpirationTimer;

        private UserCacheService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _cache = new ConcurrentDictionary<int, User>();

            _cacheExpirationTimer = new Timer(ClearCache, null, TimeSpan.FromMinutes(5), TimeSpan.FromMinutes(5));
        }

        public static UserCacheService GetInstance(IUserRepository userRepository)
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new UserCacheService(userRepository);
                    }
                }
            }
            return _instance;
        }

        // Caută un user în cache sau îl ia din DB dacă nu există
        public async Task<User?> GetUserByIdAsync(int userId)
        {
            if (_cache.TryGetValue(userId, out var user))
            {
                return user;
            }

            user = await _userRepository.GetUserByIdAsync(userId);
            if (user != null)
            {
                _cache[userId] = user;
            }

            return user;
        }

        // Adaugă user în cache după ce este adăugat în DB
        public void AddUserToCache(User user)
        {
            _cache[user.Id] = user;
        }

        // Șterge manual un utilizator din cache
        public void RemoveUserFromCache(int userId)
        {
            _cache.TryRemove(userId, out _);
        }

        // Golește cache-ul automat la fiecare 5 minute
        private void ClearCache(object? state)
        {
            _cache.Clear();
        }
    }
using System.Collections.Concurrent;
using System.Timers;
using AirportManagement.Application.Interfaces.IRepository;
using AirportManagement.Core.Models.Auth;
using Timer = System.Threading.Timer;


namespace AirportManagement.Application.Services.Cahce;

public class UserCacheService
    {
        private static UserCacheService? _instance;
        private static readonly object Lock = new();
        
        private readonly ConcurrentDictionary<Guid, User?> _cache;
        private readonly IUserRepository _userRepository;
        private readonly Timer _cacheExpirationTimer;

        private UserCacheService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _cache = new ConcurrentDictionary<Guid, User?>();

            _cacheExpirationTimer = new Timer(ClearCache, null, TimeSpan.FromMinutes(5), TimeSpan.FromMinutes(5));
        }

        public static UserCacheService GetInstance(IUserRepository userRepository)
        {
            if (_instance == null)
            {
                lock (Lock)
                {
                    if (_instance == null)
                    {
                        _instance = new UserCacheService(userRepository);
                    }
                }
            }
            return _instance;
        }
        
        public async Task<User?> GetUserByIdAsync(Guid userId)
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
        
        public void AddUserToCache(User? user)
        {
            if (user != null) _cache[user.Id] = user;
        }
        public void RemoveUserFromCache(Guid userId)
        {
            _cache.TryRemove(userId, out _);
        }
        
        private void ClearCache(object? state)
        {
            _cache.Clear();
        }
    }
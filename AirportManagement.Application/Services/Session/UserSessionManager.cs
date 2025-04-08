namespace AirportManagement.Application.Services.Session;

public class UserSessionManager
{
    private static UserSessionManager? _instance;
    private static readonly object Lock = new();
    public bool IsLoggedIn { get; private set; }

    private UserSessionManager() { }

    public static UserSessionManager Instance
    {
        get
        {
            lock (Lock)
            {
                return _instance ??= new UserSessionManager();
            }
        }
    }

    public void Login() => IsLoggedIn = true;
    public void Logout() => IsLoggedIn = false;
}
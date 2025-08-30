

using AdminPanel.Services.Interface;

namespace AdminPanel.Services;

public class AuthService : IAuthService
{
    private bool _isAuthenticated = false;
    private string _currentUser = null;

    private string adminUsername = "admin";
    private string adminPassword = "12345admin,";

    public bool Login(string username, string password)
    {
        if (username == adminUsername && password == adminPassword)
        {
            _isAuthenticated = true;
            _currentUser = username;
            return true;
        }
        return false;
    }

    public bool IsAuthenticated => _isAuthenticated;

    public string CurrentUser => _currentUser;
}
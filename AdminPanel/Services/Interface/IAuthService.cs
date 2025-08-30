
namespace AdminPanel.Services.Interface;

public interface IAuthService
{
    bool Login(string username, string password);
    bool IsAuthenticated { get; }
    string CurrentUser { get; }
}
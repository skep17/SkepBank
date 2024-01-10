namespace SkepBank.Application.Services.Authentication;

public interface IAuthenticationService
{
    AuthenticationResult Login(string userName, string password);
    AuthenticationResult Register(string userName, string password);
}

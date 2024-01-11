using SkepBank.Application.Services.Authentication.Common;

namespace SkepBank.Application.Services.Authentication.Commands;

public interface IAuthenticationCommandService
{
    AuthenticationResult Register(string userName, string password);
}

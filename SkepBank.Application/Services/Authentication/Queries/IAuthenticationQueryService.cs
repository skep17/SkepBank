using SkepBank.Application.Services.Authentication.Common;

namespace SkepBank.Application.Services.Authentication.Queries;

public interface IAuthenticationQueryService
{
    AuthenticationResult Login(string userName, string password);
}

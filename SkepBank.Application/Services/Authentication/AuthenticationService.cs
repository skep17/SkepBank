using SkepBank.Application.Common.Interfaces.Authentication;

namespace SkepBank.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public AuthenticationResult Login(string username, string password)
    {
        return new AuthenticationResult(Guid.NewGuid(), username, "token");
    }

    public AuthenticationResult Register(string username, string password)
    {
        Guid id = Guid.NewGuid();
        var token = _jwtTokenGenerator.GenerateToken(id,username);

        return new AuthenticationResult(Guid.NewGuid(), username, token);
    }
}

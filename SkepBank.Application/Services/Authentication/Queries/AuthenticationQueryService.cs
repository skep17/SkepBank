using SkepBank.Application.Common.Interfaces.Authentication;
using SkepBank.Application.Common.Interfaces.Persistence;
using SkepBank.Application.Services.Authentication.Common;
using SkepBank.Domain.Entities;

namespace SkepBank.Application.Services.Authentication.Queries;

public class AuthenticationQueryService : IAuthenticationQueryService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationQueryService(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Login(string userName, string password)
    {
        if (_userRepository.GetByUserName(userName) is not User user)
        {
            throw new Exception("User with the provided user name doesn't exist!");
        }

        if (user.Password != password)
        {
            throw new Exception($"Failed to login with password {password}");
        }

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}

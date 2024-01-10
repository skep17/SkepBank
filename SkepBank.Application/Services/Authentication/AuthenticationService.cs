using SkepBank.Application.Common.Interfaces.Authentication;
using SkepBank.Application.Common.Interfaces.Persistence;
using SkepBank.Domain.Entities;

namespace SkepBank.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(
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

    public AuthenticationResult Register(string userName, string password)
    {
        if (_userRepository.GetByUserName(userName) is not null)
        {
            throw new Exception("User with the provided username already exists!");
        }

        var user = new User { UserName = userName, Password = password };

        _userRepository.Add(user);
        
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}

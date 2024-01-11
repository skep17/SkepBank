using SkepBank.Application.Common.Interfaces.Authentication;
using SkepBank.Application.Common.Interfaces.Persistence;
using SkepBank.Application.Services.Authentication.Common;
using SkepBank.Domain.Entities;

namespace SkepBank.Application.Services.Authentication.Commands;

public class AuthenticationCommandService : IAuthenticationCommandService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationCommandService(
        IJwtTokenGenerator jwtTokenGenerator,
        IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
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

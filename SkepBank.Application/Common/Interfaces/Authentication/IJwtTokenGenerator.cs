using SkepBank.Domain.Entities;

namespace SkepBank.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}

using SkepBank.Domain.Entities;

namespace SkepBank.Application.Services.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token);

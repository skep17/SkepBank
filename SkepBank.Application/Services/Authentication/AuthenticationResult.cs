using SkepBank.Domain.Entities;

namespace SkepBank.Application.Services.Authentication;

public record AuthenticationResult(
    User User,
    string Token);

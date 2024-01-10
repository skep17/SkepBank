using Microsoft.Extensions.DependencyInjection;
using SkepBank.Application.Common.Interfaces.Authentication;
using SkepBank.Application.Common.Interfaces.Services;
using SkepBank.Infrastructure.Authentication;
using SkepBank.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using SkepBank.Application.Common.Interfaces.Persistence;
using SkepBank.Infrastructure.Persistence;

namespace SkepBank.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, ConfigurationManager configuration)
    {
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddSingleton<IUserRepository, UserRepository>();
        return services;
    }
}

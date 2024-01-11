using Microsoft.Extensions.DependencyInjection;
using SkepBank.Application.Services.Authentication.Commands;
using SkepBank.Application.Services.Authentication.Queries;

namespace SkepBank.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();
        services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();

        return services;
    }
}

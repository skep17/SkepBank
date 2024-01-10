using Microsoft.Extensions.DependencyInjection;
using SkepBank.Application.Services.Authentication;

namespace SkepBank.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();

        return services;
    }
}

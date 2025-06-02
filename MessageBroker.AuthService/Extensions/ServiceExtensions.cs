using MessageBroker.AuthService.Abstractions;
using MessageBroker.AuthService.DataAccess.Repositories;
using MessageBroker.AuthService.DataAccess.Services;
using MessageBroker.AuthService.JwtInfrastructure;

namespace MessageBroker.AuthService.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IUsersRepository, UsersRepository>();
        services.AddScoped<IUsersService, UsersService>();

        services.AddScoped<JwtProvider>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<IAuthService, DataAccess.Services.AuthService>();

        return services;
    }
}
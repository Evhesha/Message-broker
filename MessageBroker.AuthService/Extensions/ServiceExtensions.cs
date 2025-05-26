using MessageBroker.AuthService.Abstractions;
using MessageBroker.AuthService.DataAccess.Repositories;
using MessageBroker.AuthService.DataAccess.Services;

namespace MessageBroker.AuthService.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IUsersRepository, UsersRepository>();
        services.AddScoped<IUsersService, UsersService>();  

        return services;
    }
}
using MessageBroker.AuthService.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace MessageBroker.AuthService.Extensions;

public static class DataBaseExtensions
{
    public static IServiceCollection AddDataBase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        return services;
    }
}
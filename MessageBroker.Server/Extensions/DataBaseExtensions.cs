using MongoDB.Driver;

namespace MessageBroker.Server.Extensions;

public static class DataBaseExtensions
{
    public static IServiceCollection AddDataBase(this IServiceCollection services, IConfiguration configuration)
    {
        string mongoConnectionString = configuration.GetConnectionString("MongoConnection");
        services.AddSingleton<IMongoClient>(new MongoClient(mongoConnectionString));

        return services;
    }
}
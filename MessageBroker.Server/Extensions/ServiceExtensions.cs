using MessageBroker.Server.Abstractions;
using MessageBroker.Server.MongoDataAccess;
using MessageBroker.Server.MongoDataAccess.Services;

namespace MessageBroker.Server.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IChatsRepository, ChatsRepository>();
        services.AddScoped<IChatsService, ChatsService>();
        
        services.AddScoped<IMessagesRepository, MessagesRepository>();
        services.AddScoped<IMessagesService, MessagesService>();

        return services;
    }
}
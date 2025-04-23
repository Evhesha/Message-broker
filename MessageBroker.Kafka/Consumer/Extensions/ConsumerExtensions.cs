using MessageBroker.Kafka.Consumer.Abstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MessageBroker.Kafka.Consumer.Extensions;

public static class ConsumerExtensions
{
    public static IServiceCollection AddKafkaConsumer<TMessage, THandler>(
        this IServiceCollection services,
        IConfigurationSection consumerSection)
    where THandler : class, IMessageHandler<TMessage>
    {
        services.Configure<KafkaConsumerSettings>(consumerSection);
        services.AddHostedService<KafkaConsumer<TMessage>>();
        services.AddSingleton<IMessageHandler<TMessage>, THandler>();
        
        return services;
    }
}
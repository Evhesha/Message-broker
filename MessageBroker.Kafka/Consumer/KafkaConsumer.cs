using Confluent.Kafka;
using MessageBroker.Kafka.Consumer.Abstractions;
using MessageBroker.Kafka.Consumer.Deserializers;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace MessageBroker.Kafka.Consumer;

public class KafkaConsumer<TMessage> : BackgroundService
{
    private readonly IMessageHandler<TMessage> _handler;
    private readonly string _topic;
    private readonly IConsumer<string, TMessage> _consumer;

    public KafkaConsumer(
        IOptions<KafkaConsumerSettings> settings,
        IMessageHandler<TMessage> handler)
    {
        _handler = handler;
        var config = new ConsumerConfig
        {
            BootstrapServers = settings.Value.BootstrapServers,
            AutoOffsetReset = AutoOffsetReset.Earliest,
            GroupId = settings.Value.GroupId
        };
        
        _topic = settings.Value.Topic;
        
        _consumer = new ConsumerBuilder<string, TMessage>(config)
            .SetValueDeserializer(new KafkaValueDeserializer<TMessage>())
            .Build();
    }
    
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        return Task.Run(() => ConsumerAsync(stoppingToken), stoppingToken);
    }

    private async Task? ConsumerAsync(CancellationToken stoppingToken)
    {
        _consumer.Subscribe(_topic);

        try
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var result = _consumer.Consume(stoppingToken);
                await _handler.HandleAsync(result.Message.Value, stoppingToken);   
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public override Task StopAsync(CancellationToken cancellationToken)
    {
        _consumer.Close();
        return base.StopAsync(cancellationToken);
    }
}
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace MessageBroker.Kafka.Consumer;

public class KafkaServerConsumer<TMessage> : BackgroundService
{
    public KafkaServerConsumer(IOptions<KafkaConsumerSettings> settings)
    {
        
    }
    
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        throw new NotImplementedException();
    }
}
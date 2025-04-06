using Confluent.Kafka;
using MessageBroker.Kafka.Producer.Abstractions;
using MessageBroker.Kafka.Producer.Serializers;
using Microsoft.Extensions.Options;

namespace MessageBroker.Kafka.Producer;

public class KafkaOllamaProducer<TMessage> : IKafkaProducer<TMessage>
{
    private readonly IProducer<string, TMessage> producer;
    private readonly string topic;

    public KafkaOllamaProducer(IOptions<KafkaProducerSettings> kafkaSettings)
    {
        var config = new ProducerConfig
        {
            BootstrapServers = kafkaSettings.Value.BootstrapServers,
        };
        
         producer = new ProducerBuilder<string, TMessage>(config)
            .SetValueSerializer(new KafkaJsonSerializer<TMessage>())
            .Build();
         
         topic = kafkaSettings.Value.Topic;
    }
    
    public async Task ProduceAsync(TMessage message, CancellationToken cancellationToken = default)
    {
        await producer.ProduceAsync(topic, new Message<string, TMessage>
            { 
                Key = "unig1",
                Value = message 
            },
            cancellationToken);
    }

    public void Dispose()
    {
        producer?.Dispose();
    }
}
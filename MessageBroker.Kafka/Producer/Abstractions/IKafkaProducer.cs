namespace MessageBroker.Kafka.Producer.Abstractions;

public interface IKafkaProducer<in TMessage> : IDisposable
{
    Task ProduceAsync(TMessage message, CancellationToken cancellationToken = default);
}
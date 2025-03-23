namespace MessageBroker.Kafka.Producer.Abstractions;

public interface IKafkaProducer<TMessage> : IDisposable
{
    Task ProduceAsync(TMessage message, CancellationToken cancellationToken = default);
}
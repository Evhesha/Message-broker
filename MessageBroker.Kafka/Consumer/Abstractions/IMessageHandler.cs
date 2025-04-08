namespace MessageBroker.Kafka.Consumer.Abstractions;

public interface IMessageHandler<in TMessage>
{
    Task HandleAsync(TMessage message, CancellationToken cancellationToken);
}
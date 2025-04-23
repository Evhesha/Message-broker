using MessageBroker.Kafka.Consumer.Abstractions;
using MessageBroker.Kafka.Producer.Abstractions;

namespace MessageBroker.Kafka;

public class AnswerMessageHandler : IMessageHandler<string>
{
    private readonly IKafkaProducer<string> _kafkaProducer;

    public AnswerMessageHandler(IKafkaProducer<string> kafkaProducer)
    {
        _kafkaProducer = kafkaProducer;
    }
    public async Task HandleAsync(string answer, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Answer: {answer}");
    }
}
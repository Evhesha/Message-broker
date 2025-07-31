using MessageBroker.Kafka.Consumer.Abstractions;
using MessageBroker.Kafka.Models;
using MessageBroker.Kafka.Producer.Abstractions;

using Microsoft.Extensions.AI;

public class QuestionMessageHandler : IMessageHandler<QuestionMessage>
{
    private readonly IChatClient _chatClient;
    private readonly IKafkaProducer<AnswerMessage> _kafkaProducer;

    public QuestionMessageHandler(IChatClient chatClient, IKafkaProducer<AnswerMessage> kafkaProducer)
    {
        _chatClient = chatClient;
        _kafkaProducer = kafkaProducer;
    }

    public async Task HandleAsync(QuestionMessage message, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Received message from Kafka ollama question: {message}");
        
        var chatResponse = await _chatClient.GetResponseAsync(message.Question);

        var answer = new AnswerMessage
        {
            ChatId = message.ChatId,
            Messages = chatResponse.Messages
        };
        await _kafkaProducer.ProduceAsync(answer, cancellationToken);

        Console.WriteLine("Answer processed and sent to answer Kafka topic!");
    }
}
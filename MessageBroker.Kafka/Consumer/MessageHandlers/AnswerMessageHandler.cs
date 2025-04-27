using MessageBroker.Kafka.Consumer.Abstractions;
using MessageBroker.Kafka.Models;

public class AnswerMessageHandler : IMessageHandler<List<OllamaMessage>>
{
    private readonly IMessageSender _messageSender;

    public AnswerMessageHandler(IMessageSender messageSender)
    {
        _messageSender = messageSender;
    }

    public async Task HandleAsync(List<OllamaMessage> messages, CancellationToken cancellationToken)
    {
        try
        {
            foreach (var message in messages)
            {
                foreach (var content in message.Contents)
                {
                    Console.WriteLine($"Text: {content.Text}");
                    await _messageSender.SendMessage(content.Text); // Отправляем только текст
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during processing: {ex.Message}");
        }
    }
}
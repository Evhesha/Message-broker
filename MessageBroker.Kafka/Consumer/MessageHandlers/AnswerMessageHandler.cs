using MessageBroker.Kafka.Consumer.Abstractions;
using MessageBroker.Server.Responses;

public class AnswerMessageHandler : IMessageHandler<OllamaResponse>
{
    private readonly IMessageSender _messageSender;

    public AnswerMessageHandler(IMessageSender messageSender)
    {
        _messageSender = messageSender;
    }

    public async Task HandleAsync(OllamaResponse response, CancellationToken cancellationToken)
    {
        try
        {
            foreach (var message in response.Messages)
            {
                foreach (var content in message.Contents)
                {
                    await _messageSender.SendMessage(content.Text, response.ChatId);
                    Console.WriteLine("Answer was received!");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during processing: {ex.Message}");
        }
    }
}
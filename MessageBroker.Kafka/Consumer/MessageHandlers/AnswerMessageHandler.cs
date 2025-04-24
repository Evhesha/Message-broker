using MessageBroker.Kafka.Consumer.Abstractions;
using MessageBroker.Kafka.Models;
using Newtonsoft.Json;

namespace MessageBroker.Kafka;

public class AnswerMessageHandler : IMessageHandler<List<OllamaMessage>>
{
    public async Task HandleAsync(List<OllamaMessage> messages, CancellationToken cancellationToken)
    {
        try
        {
            foreach (var message in messages)
            {
                foreach (var content in message.Contents)
                {
                    Console.WriteLine($"Text: {content.Text}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error during processing: {ex.Message}");
        }
    }
}


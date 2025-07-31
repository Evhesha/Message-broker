using MessageBroker.Kafka.Models;

namespace MessageBroker.Server.Responses;

public class OllamaResponse
{
    public string ChatId { get; set; }
    public List<OllamaMessage> Messages { get; set; }
}
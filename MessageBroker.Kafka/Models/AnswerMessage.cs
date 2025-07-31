using Microsoft.Extensions.AI;

namespace MessageBroker.Kafka.Models;

public class AnswerMessage
{
    public string ChatId { get; set; }
    public IList<ChatMessage> Messages { get; set; }
}
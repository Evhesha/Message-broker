namespace MessageBroker.Kafka.Models;

public class QuestionMessage
{
    public string Question { get; set; } = string.Empty;
    public string ChatId { get; set; } = string.Empty;
}
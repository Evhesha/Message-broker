namespace MessageBroker.Server;

public class QuestionKafkaMessage
{
    public string Question { get; set; } = string.Empty;
    public string ChatId { get; set; } = string.Empty;
}
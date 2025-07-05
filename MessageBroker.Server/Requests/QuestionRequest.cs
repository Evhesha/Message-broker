namespace MessageBroker.Server;

public class QuestionRequest
{
    public string Question { get; set; } = string.Empty;
    public string ChatId { get; set; } = string.Empty;
}
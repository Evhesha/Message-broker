namespace MessageBroker.Server.Models;

public class Message
{
    public int Id { get; set; }
    public string UserMessage { get; set; } = string.Empty;
    public string BotResponse { get; set; } = string.Empty;
    public DateTime Date { get; set; }
}
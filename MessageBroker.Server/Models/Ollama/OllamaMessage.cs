namespace MessageBroker.Server.Models.Ollama;

public class OllamaMessage
{
    public string? AuthorName { get; set; }
    public string? Role { get; set; }
    public List<OllamaContent> Contents { get; set; } = new();
    public string? MessageId { get; set; }
    public object? AdditionalProperties { get; set; }
}
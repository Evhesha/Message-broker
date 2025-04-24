using System.Text.Json.Serialization;

namespace MessageBroker.Server.Models.Ollama;

public class OllamaContent
{
    [JsonPropertyName("Text")]
    public string Text { get; set; }

    [JsonPropertyName("$type")]
    public string Type { get; set; }
}
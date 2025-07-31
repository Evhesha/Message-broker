using System.Text.Json.Serialization;

namespace MessageBroker.Kafka.Models;

public class OllamaMessage
{
    [JsonPropertyName("AuthorName")]
    public string AuthorName { get; set; }
    
    [JsonPropertyName("ChatId")]
    public string ChatId { get; set; }

    [JsonPropertyName("Role")]
    public string Role { get; set; }

    [JsonPropertyName("Contents")]
    public List<Content> Contents { get; set; }

    [JsonPropertyName("MessageId")]
    public string MessageId { get; set; }

    [JsonPropertyName("AdditionalProperties")]
    public object AdditionalProperties { get; set; }
}
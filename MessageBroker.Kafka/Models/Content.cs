using System.Text.Json.Serialization;

namespace MessageBroker.Kafka.Models;

public class Content
{
    [JsonPropertyName("$type")]
    public string Type { get; set; }

    [JsonPropertyName("Text")]
    public string Text { get; set; }

    [JsonPropertyName("AdditionalProperties")]
    public object AdditionalProperties { get; set; }
}
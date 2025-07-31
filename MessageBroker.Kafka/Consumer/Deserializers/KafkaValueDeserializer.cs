using System.Text.Json;
using System.Text.Json.Serialization;
using Confluent.Kafka;

namespace MessageBroker.Kafka.Consumer.Deserializers;

public class KafkaValueDeserializer<TMessage> : IDeserializer<TMessage>
{
    public TMessage Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            IncludeFields = true
        };
        options.Converters.Add(new JsonStringEnumConverter());
        
        return JsonSerializer.Deserialize<TMessage>(data, options)!;
    }
}
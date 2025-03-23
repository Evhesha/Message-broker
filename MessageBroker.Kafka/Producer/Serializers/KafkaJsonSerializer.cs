﻿using System.Text.Json;
using Confluent.Kafka;

namespace MessageBroker.Kafka.Producer.Serializers;

public class KafkaJsonSerializer<TMessage> : ISerializer<TMessage>
{
    public byte[] Serialize(TMessage data, SerializationContext context)
    {
        return JsonSerializer.SerializeToUtf8Bytes(data);
    }
}
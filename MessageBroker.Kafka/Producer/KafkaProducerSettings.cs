namespace MessageBroker.Kafka;

public class KafkaProducerSettings
{
    public string BootstrapServers { get; set; } = string.Empty;
    public string Topic { get; set; } = string.Empty;
}
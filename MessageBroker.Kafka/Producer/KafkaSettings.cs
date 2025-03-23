namespace MessageBroker.Kafka.Producer;

public class KafkaSettings
{
    public string BootstrapServers { get; set; } = string.Empty;
    public string Topic { get; set; } = string.Empty;
}
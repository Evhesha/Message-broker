﻿using MessageBroker.Kafka.Consumer;
using MessageBroker.Kafka.Consumer.Abstractions;
using MessageBroker.Kafka.Producer.Abstractions;

using Microsoft.Extensions.AI;

public class QuestionMessageHandler : IMessageHandler<string>
{
    private readonly IChatClient _chatClient;
    private readonly IKafkaProducer<IList<ChatMessage>> _kafkaProducer;

    public QuestionMessageHandler(IChatClient chatClient, IKafkaProducer<IList<ChatMessage>> kafkaProducer)
    {
        _chatClient = chatClient;
        _kafkaProducer = kafkaProducer;
    }

    public async Task HandleAsync(string message, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Received message from Kafka: {message}");

        // AI-клиент обрабатывает сообщение
        var chatResponse = await _chatClient.GetResponseAsync(message);

        // Отправляем ответ в другой топик Kafka
        await _kafkaProducer.ProduceAsync(chatResponse.Messages, cancellationToken);

        Console.WriteLine("Answer processed and sent to another Kafka topic!");
    }
}
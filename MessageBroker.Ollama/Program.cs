using MessageBroker.Kafka.Consumer.Extensions;
using MessageBroker.Kafka.Producer.Extensions;
using MessageBroker.Server.Models;
using Microsoft.Extensions.AI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

// **Регистрируем Kafka Consumer (он автоматически слушает сообщения)**
builder.Services.AddKafkaConsumer<string, QuestionMessageHandler>(builder.Configuration.GetSection("Kafka:Question"));

// **Регистрируем Kafka Producer (отправляет обработанные ответы в Kafka)**
builder.Services.AddKafkaProducer<IList<ChatMessage>>(builder.Configuration.GetSection("Kafka:Ollama"));

// **Регистрируем AI-клиент**
builder.Services.AddChatClient(new OllamaChatClient(new Uri("http://localhost:11434"), "tinyllama"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
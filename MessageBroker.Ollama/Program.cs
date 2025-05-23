using MessageBroker.Kafka.Consumer.Extensions;
using MessageBroker.Kafka.Producer.Extensions;
using Microsoft.Extensions.AI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddKafkaProducer<IList<ChatMessage>>(builder.Configuration.GetSection("Kafka:Ollama"));
builder.Services.AddKafkaConsumer<string, QuestionMessageHandler>(builder.Configuration.GetSection("Kafka:Question"));
builder.Services.AddChatClient(new OllamaChatClient(new Uri("http://localhost:11434"), "tinyllama"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();
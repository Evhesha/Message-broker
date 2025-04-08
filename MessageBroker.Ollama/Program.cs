using MessageBroker.Kafka.Producer.Abstractions;
using MessageBroker.Kafka.Producer.Extensions;
using MessageBroker.Server.Models;
using Microsoft.Extensions.AI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddKafkaProducer<IList<ChatMessage>>(builder.Configuration.GetSection("Kafka:Ollama"));
builder.Services.AddChatClient(new OllamaChatClient(new Uri("http://localhost:11434"), "tinyllama"));

var app = builder.Build();

var chatClient = app.Services.GetRequiredService<IChatClient>();

var chatResponse = await chatClient.GetResponseAsync("What is .NET");


if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapPost("/create-ollama-answer", async (IKafkaProducer<IList<ChatMessage>> kafkaProducer, HttpContext httpContext) => 
{
    Console.WriteLine("Отправка сообщения в Kafka...");
    await kafkaProducer.ProduceAsync(chatResponse.Messages, default);
    Console.WriteLine("Сообщение отправлено!");
});


app.Run();
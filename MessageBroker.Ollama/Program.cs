using MessageBroker.Kafka.Consumer;
using MessageBroker.Kafka.Consumer.Extensions;
using MessageBroker.Kafka.Producer.Abstractions;
using MessageBroker.Kafka.Producer.Extensions;
using MessageBroker.Server.Models;
using Microsoft.Extensions.AI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddKafkaProducer<IList<ChatMessage>>(builder.Configuration.GetSection("Kafka:Ollama"));
builder.Services.AddChatClient(new OllamaChatClient(new Uri("http://localhost:11434"), "tinyllama"));

builder.Services.AddKafkaConsumer<string, QuestionMessageHandler>(
    builder.Configuration.GetSection("Kafka:Question"));

var app = builder.Build();

var chatClient = app.Services.GetRequiredService<IChatClient>();

Console.WriteLine("Write your question --> ");
string question = Console.ReadLine();
var chatResponse = await chatClient.GetResponseAsync(question);

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapPost("/create-ollama-answer", async (IKafkaProducer<IList<ChatMessage>> kafkaProducer, HttpContext httpContext) => 
{
    Console.WriteLine("Requesting a message to Kafka from ollama service...");
    await kafkaProducer.ProduceAsync(chatResponse.Messages, default);
    Console.WriteLine("Message sent to Kafka!");
});

app.Run();
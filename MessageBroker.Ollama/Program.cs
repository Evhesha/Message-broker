using MessageBroker.Kafka.Producer.Abstractions;
using MessageBroker.Kafka.Producer.Extensions;
using MessageBroker.Server.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddKafkaProducer<string>(builder.Configuration.GetSection("Kafka:Ollama"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapPost("/create-ollama-answer", async (IKafkaProducer<string> kafkaProducer) => 
{
    Console.WriteLine("Отправка сообщения в Kafka...");
    await kafkaProducer.ProduceAsync("ollama answer !!!!", default);
    Console.WriteLine("Сообщение отправлено!");
});

app.Run();
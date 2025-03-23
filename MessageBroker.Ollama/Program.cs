using MessageBroker.Kafka.Producer.Abstractions;
using MessageBroker.Kafka.Producer.Extensions;
using MessageBroker.Server.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();
builder.Services.AddKafkaProducer<Message>(builder.Configuration.GetSection("Kafka:Message"));
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// app.MapPost("/KafkaOllama", async (IKafkaProducer<Message> kafkaProducer) =>
// {
//     await kafkaProducer.ProduceAsync(new Message
//     {
//         Id = Guid.NewGuid().ToString(),
//         
//     });
// });

app.Run();
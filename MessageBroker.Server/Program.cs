using MessageBroker.Kafka.Producer.Abstractions;
using MessageBroker.Kafka.Producer.Extensions;
using MessageBroker.Server.Extensions;
using Microsoft.Extensions.AI;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddCors();
builder.Services.AddOpenApi();

builder.Services.AddCustomCors(builder.Configuration);
builder.Services.AddDataBase(builder.Configuration);

builder.Services.AddKafkaProducer<string>(builder.Configuration.GetSection("Kafka:Question"));

var app = builder.Build();

Console.Write("Write your question --> ");
string question = Console.ReadLine();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapPost("/create-ollama-question", async (HttpContext httpContext) =>
{
    var kafkaProducer = httpContext.RequestServices.GetRequiredService<IKafkaProducer<string>>();

    Console.WriteLine("Requesting a message to Kafka from server...");
    await kafkaProducer.ProduceAsync(question, default);
    Console.WriteLine("Message sent to Kafka!");
});


app.Run();
using MessageBroker.Kafka.Consumer.Extensions;
using MessageBroker.Kafka.Producer.Extensions;
using MessageBroker.Server.Extensions;
using MessageBroker.Server.Hubs;
using OllamaMessage = MessageBroker.Kafka.Models.OllamaMessage;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddCors();
builder.Services.AddOpenApi();
builder.Services.AddCustomCors(builder.Configuration);
builder.Services.AddDataBase(builder.Configuration);

builder.Services.AddSingleton<IMessageSender, SignalRMessageSender>();

builder.Services.AddSignalR();

builder.Services.AddKafkaProducer<string>(builder.Configuration.GetSection("Kafka:Question"));
builder.Services.AddKafkaConsumer<List<OllamaMessage>,
    AnswerMessageHandler>(builder.Configuration.GetSection("Kafka:Ollama"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseCors("AllowSpecificOrigin");
app.UseAuthorization();
app.MapHub<MessageHub>("/messageHub");
app.MapControllers();
app.Run();
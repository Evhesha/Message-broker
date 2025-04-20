using MessageBroker.Kafka.Producer.Extensions;
using MessageBroker.Server.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddCors();
builder.Services.AddOpenApi();
builder.Services.AddCustomCors(builder.Configuration);
builder.Services.AddDataBase(builder.Configuration);
builder.Services.AddKafkaProducer<string>(builder.Configuration.GetSection("Kafka:Question"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors("AllowSpecificOrigin");

app.Run();
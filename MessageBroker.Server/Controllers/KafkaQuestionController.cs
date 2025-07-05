using MessageBroker.Kafka.Producer.Abstractions;
using MessageBroker.Server.Abstractions;
using MessageBroker.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace MessageBroker.Server.Controllers;

[ApiController]
[Route("api/kafka")]
public class KafkaController : ControllerBase
{
    private readonly IKafkaProducer<string> _kafkaProducer;
    private readonly IMessagesService  _messagesService;

    public KafkaController(
        IKafkaProducer<string> kafkaProducer,
        IMessagesService messagesService)
    {
        _kafkaProducer = kafkaProducer;
        _messagesService = messagesService;
    }

    [HttpPost("create-ollama-question")]
    public async Task<IActionResult> SendKafkaMessage([FromBody] QuestionRequest request)
    {
        Console.WriteLine("Produce message to Kafka...");
        await _kafkaProducer.ProduceAsync(request.Question, default);
        Console.WriteLine("Message sent to Kafka!");
        
        var message = new Message
        {
            Type = "userMessage",
            Text = request.Question,
            Date = DateTime.Now
        };
        
        await _messagesService.AddMessageToChat(request.ChatId, message);

        return Ok(new { message = "Message sent to Kafka!" });
    }
}
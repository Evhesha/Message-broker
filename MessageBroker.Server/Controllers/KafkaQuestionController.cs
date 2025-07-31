using MessageBroker.Kafka.Producer.Abstractions;
using MessageBroker.Server.Abstractions;
using MessageBroker.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace MessageBroker.Server.Controllers;

[ApiController]
[Route("api/kafka")]
public class KafkaController : ControllerBase
{
    private readonly IKafkaProducer<QuestionKafkaMessage> _kafkaProducer;
    private readonly IMessagesService  _messagesService;

    public KafkaController(
        IKafkaProducer<QuestionKafkaMessage> kafkaProducer,
        IMessagesService messagesService)
    {
        _kafkaProducer = kafkaProducer;
        _messagesService = messagesService;
    }

    [HttpPost("create-ollama-question")]
    public async Task<IActionResult> SendKafkaMessage([FromBody] QuestionRequest request)
    {
        var message = new QuestionKafkaMessage
        {
            Question = request.Question,
            ChatId = request.ChatId
        };
        
        await _kafkaProducer.ProduceAsync(message);
        Console.WriteLine("Message sent to Kafka!");
        
        var userMessage = new Message
        {
            Type = "userMessage",
            Text = request.Question,
            Date = DateTime.Now,
        };
        
        await _messagesService.AddMessageToChat(request.ChatId, userMessage);

        return Ok(new { message = "Message sent to Kafka!" });
    }
}
using MessageBroker.Kafka.Producer.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace MessageBroker.Server.Controllers;

[ApiController]
[Route("api/kafka")]
public class KafkaController : ControllerBase
{
    private readonly IKafkaProducer<string> _kafkaProducer;

    public KafkaController(IKafkaProducer<string> kafkaProducer)
    {
        _kafkaProducer = kafkaProducer;
    }

    [HttpPost("create-ollama-question")]
    public async Task<IActionResult> SendKafkaMessage([FromBody] QuestionRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Question))
        {
            return BadRequest("The question can't be empty.");
        }

        Console.WriteLine("Produce message to Kafka...");
        await _kafkaProducer.ProduceAsync(request.Question, default);
        Console.WriteLine("Message sent to Kafka!");

        return Ok(new { message = "Message sent to Kafka!" });
    }
}
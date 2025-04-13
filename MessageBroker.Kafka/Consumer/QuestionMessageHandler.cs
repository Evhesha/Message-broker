using System.Text;
using System.Text.Json;
using MessageBroker.Kafka.Consumer.Abstractions;

namespace MessageBroker.Kafka.Consumer;

public class QuestionMessageHandler : IMessageHandler<string>
{
    private readonly HttpClient _httpClient;

    public QuestionMessageHandler()
    {
        _httpClient = new HttpClient(); // HttpClient для отправки POST
    }

    public async Task HandleAsync(string message, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Received message: {message}");

        var postContent = new StringContent(
            JsonSerializer.Serialize(new { Question = message }), // Тело запроса
            Encoding.UTF8,
            "application/json");

        try
        {
            // Отправляем POST-запрос
            var response = await _httpClient.PostAsync("https://localhost:5001/create-ollama-answer", postContent, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Message successfully posted to /create-ollama-answer.");
            }
            else
            {
                Console.WriteLine($"Failed to post message. Status code: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while posting message: {ex.Message}");
        }
    }
}
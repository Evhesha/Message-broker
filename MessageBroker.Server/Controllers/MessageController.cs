using MessageBroker.Server.Abstractions;
using MessageBroker.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace MessageBroker.Server.Controllers;

[ApiController]
[Route("api/message")]
public class MessageController : ControllerBase
{
    private readonly IMessagesService _messagesService;
    
    public MessageController(IMessagesService messagesService)
    {
        _messagesService = messagesService;
    }

    [HttpGet("{chatId}")]
    public async Task<List<Message>> GetMessagesFromChat(string chatId)
    {
        return await _messagesService.GetMessagesByChatIdAsync(chatId);   
    }

    [HttpPost("{chatId}/send")]
    public async Task<IActionResult> SendMessageToChat(string chatId, [FromBody] string messageAsked)
    {
        var message = new Message
        {
            Type = "userMessage",
            Text = messageAsked,
            Date = DateTime.Now,
        };
        
        await _messagesService.AddMessageToChat(chatId, message);
        return Ok(new { status = "Message added" });
    }
}
using MessageBroker.Server.Abstractions;
using MessageBroker.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace MessageBroker.Server.Controllers;

[ApiController]
[Route("api/chat")]
public class ChatController : ControllerBase
{
    private readonly IChatsService _chatsService;

    public ChatController(IChatsService chatsService)
    {
        _chatsService = chatsService;
    }

    /*public async Task<ActionResult> CreateChat(Chat chat)
    {
        var chatEntity = new Chat
        {
            
        };
    }
    */

}
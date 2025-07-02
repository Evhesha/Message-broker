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

    [HttpGet("{userId}")]
    public async Task<ActionResult<List<Chat>>> GetUserChats([FromRoute] string userId)
    {
        var chats = await _chatsService.GetChatsByUserId(userId);

        if (chats == null || chats.Count == 0)
            return NotFound("There are no chats for this user");

        return Ok(chats);
    }

    [HttpPost]
    public async Task<ActionResult> CreateChat([FromBody] Chat chat)
    {
        var chatEntity = new Chat
        {
            UserId = chat.UserId,
            ChatName = chat.ChatName,
            Messages = new List<Message>()
        };

        await _chatsService.CreateChat(chatEntity);
        return Ok("Chat was created");
    }

    [HttpDelete("{chatId}")]
    public async Task<ActionResult> DeleteChat(string chatId)
    {
        try
        {
            await _chatsService.DeleteChat(chatId);
        }
        catch (Exception)
        {
            return BadRequest("There is no chat with such id");
        }
        
        return Ok("Chat was deleted successfully");
    }
}
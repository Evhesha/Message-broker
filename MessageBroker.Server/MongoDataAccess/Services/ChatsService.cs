using MessageBroker.Server.Abstractions;
using MessageBroker.Server.Models;

namespace MessageBroker.Server.MongoDataAccess.Services;

public interface IChatsService
{
    Task<List<Chat>> GetChatsByUserId(string userId);
    Task CreateChat(Chat chat);
    Task DeleteChat(string id);
}

public class ChatsService : IChatsService
{
    private readonly IChatRepository _chatRepository;

    public ChatsService(IChatRepository chatRepository)
    {
        _chatRepository = chatRepository;
    }

    public async Task<List<Chat>> GetChatsByUserId(string userId)
    {
        return await _chatRepository.GetChatsByUserId(userId);
    }
    
    public async Task CreateChat(Chat chat)
    {
        await _chatRepository.CreateChat(chat);
    }

    public async Task DeleteChat(string id)
    { 
        await _chatRepository.DeleteChat(id);
    }
}
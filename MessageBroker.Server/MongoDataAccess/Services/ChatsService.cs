using MessageBroker.Server.Abstractions;
using MessageBroker.Server.Models;

namespace MessageBroker.Server.MongoDataAccess.Services;

public class ChatsService : IChatsService
{
    private readonly IChatsRepository _chatsRepository;

    public ChatsService(IChatsRepository chatsRepository)
    {
        _chatsRepository = chatsRepository;
    }

    public async Task<List<Chat>> GetChatsByUserId(string userId)
    {
        return await _chatsRepository.GetChatsByUserId(userId);
    }
    
    public async Task CreateChat(Chat chat)
    {
        await _chatsRepository.CreateChat(chat);
    }

    public async Task DeleteChat(string id)
    { 
        await _chatsRepository.DeleteChat(id);
    }
}
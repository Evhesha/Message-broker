using MessageBroker.Server.Abstractions;
using MessageBroker.Server.Models;

namespace MessageBroker.Server.MongoDataAccess.Services;

public class MessagesService
{
    private readonly IMessagesRepository  _messagesRepository;
    
    public MessagesService(IMessagesRepository messagesRepository)
    {
        _messagesRepository = messagesRepository;
    }

    public async Task<List<Message>> GetMessagesByChatIdAsync(string chatId)
    {
        return await _messagesRepository.GetMessagesByChatId(chatId);
    }

    public async Task AddMessageToChat(string chatId, Message message)
    {
        await _messagesRepository.AddMessageToChat(chatId, message);
    }
}
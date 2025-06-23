using MessageBroker.Server.Models;

namespace MessageBroker.Server.Abstractions;

public interface IMessagesRepository
{
    Task<List<Message>> GetMessagesByChatId(string chatId);
    Task AddMessageToChat(string chatId, Message message);
}
using MessageBroker.Server.Models;

namespace MessageBroker.Server.Abstractions;

public interface IMessagesService
{
    Task<List<Message>> GetMessagesByChatIdAsync(string chatId);
    Task AddMessageToChat(string chatId, Message message);
}
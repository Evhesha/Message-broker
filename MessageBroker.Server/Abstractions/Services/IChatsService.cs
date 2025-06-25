using MessageBroker.Server.Models;

namespace MessageBroker.Server.Abstractions;

public interface IChatsService
{
    Task<List<Chat>> GetChatsByUserId(string userId);
    Task CreateChat(Chat chat);
    Task DeleteChat(string id);
}
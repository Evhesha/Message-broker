using MessageBroker.Server.Models;
using MongoDB.Driver;

namespace MessageBroker.Server.MongoDataAccess;

public interface IMessagesRepository
{
    Task<List<Message>> GetMessagesByChatIdAsync(string chatId);
    Task AddMessageToChatAsync(string chatId, Message message);
}

public class MessagesRepository : IMessagesRepository
{
    private readonly IMongoCollection<Chat> _chatCollection;

    public MessagesRepository(IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase("ChatDatabase");
        _chatCollection = database.GetCollection<Chat>("Chats");
    }
    
    public async Task<List<Message>> GetMessagesByChatIdAsync(string chatId)
    {
        var filter = Builders<Chat>.Filter.Eq("_id", chatId);
        var chat = await _chatCollection.Find(filter).FirstOrDefaultAsync();
        return chat?.Messages ?? new List<Message>();
    }
    
    public async Task AddMessageToChatAsync(string chatId, Message message)
    {
        var filter = Builders<Chat>.Filter.Eq("_id", chatId);
        var update = Builders<Chat>.Update.Push("messages", message);
        await _chatCollection.UpdateOneAsync(filter, update);
    }
}
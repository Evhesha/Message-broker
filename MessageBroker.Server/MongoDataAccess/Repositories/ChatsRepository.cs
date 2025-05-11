using MessageBroker.Server.Models;
using MongoDB.Driver;

namespace MessageBroker.Server.MongoDataAccess;

public class ChatRepository
{
    private readonly IMongoCollection<Chat> _chatCollection;

    public ChatRepository(IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase("ChatDatabase");
        _chatCollection = database.GetCollection<Chat>("Chats");
    }

    public async Task<Chat> GetChatByUserIdAsync(string userId)
    {
        var filter = Builders<Chat>.Filter.Eq("userId", userId);
        return await _chatCollection.Find(filter).FirstOrDefaultAsync();
    }
    
    public async Task CreateChatAsync(Chat chat)
    {
        await _chatCollection.InsertOneAsync(chat);
    }
    
    public async Task AddMessageToChatAsync(string chatId, Message message)
    {
        var filter = Builders<Chat>.Filter.Eq("_id", chatId);
        var update = Builders<Chat>.Update.Push("messages", message);
        await _chatCollection.UpdateOneAsync(filter, update);
    }
}
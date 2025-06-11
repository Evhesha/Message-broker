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

    public async Task<List<Chat>> GetChatsByUserId(string userId)
    {
        var filter = Builders<Chat>.Filter.Eq("userId", userId);
        return await _chatCollection.Find(filter).ToListAsync();
    }
    
    public async Task CreateChat(Chat chat)
    {
        await _chatCollection.InsertOneAsync(chat);
    }
}
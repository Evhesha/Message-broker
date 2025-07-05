using MessageBroker.Server.Abstractions;
using MessageBroker.Server.Models;
using MongoDB.Driver;

namespace MessageBroker.Server.MongoDataAccess;

public class MessagesRepository : IMessagesRepository
{
    private readonly IMongoCollection<Chat> _chatCollection;

    public MessagesRepository(IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase("ChatDatabase");
        _chatCollection = database.GetCollection<Chat>("Chats");
    }
    
    public async Task<List<Message>> GetMessagesByChatId(string chatId)
    {
        var filter = Builders<Chat>.Filter.Eq(c => c.Id, chatId);
        var chat = await _chatCollection.Find(filter).FirstOrDefaultAsync();
        return chat?.Messages ?? new List<Message>();
    }
    
    public async Task AddMessageToChat(string chatId, Message message)
    {
        var filter = Builders<Chat>.Filter.Eq(c => c.Id, chatId);
        var update = Builders<Chat>.Update.Push("messages", message);
        await _chatCollection.UpdateOneAsync(filter, update);
    }
}
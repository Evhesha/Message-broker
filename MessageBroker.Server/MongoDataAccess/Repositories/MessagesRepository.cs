using MessageBroker.Server.Models;
using MongoDB.Driver;

namespace MessageBroker.Server.MongoDataAccess;

public class MessagesRepository
{
    private readonly IMongoCollection<Chat> _chatCollection;

    public MessagesRepository(IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase("ChatDatabase");
        _chatCollection = database.GetCollection<Chat>("Chats");
    }

    // Получить сообщения конкретного чата
    public async Task<List<Message>> GetMessagesByChatIdAsync(string chatId)
    {
        var filter = Builders<Chat>.Filter.Eq("_id", chatId);
        var chat = await _chatCollection.Find(filter).FirstOrDefaultAsync();
        return chat?.Messages ?? new List<Message>();
    }

    // Добавить сообщение в чат
    public async Task AddMessageToChatAsync(string chatId, Message message)
    {
        var filter = Builders<Chat>.Filter.Eq("_id", chatId);
        var update = Builders<Chat>.Update.Push("messages", message);
        await _chatCollection.UpdateOneAsync(filter, update);
    }
}
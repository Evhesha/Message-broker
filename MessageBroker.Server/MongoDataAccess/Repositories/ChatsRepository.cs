using MessageBroker.Server.Abstractions;
using MessageBroker.Server.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using MongoDB.Driver;

namespace MessageBroker.Server.MongoDataAccess;

public class ChatsRepository : IChatsRepository
{
    private readonly IMongoCollection<Chat> _chatCollection;

    public ChatsRepository(IMongoClient mongoClient)
    {
        var database = mongoClient.GetDatabase("ChatDatabase");
        _chatCollection = database.GetCollection<Chat>("Chats");
    }

    public async Task<List<Chat>> GetChatsByUserId(string userId)
    {
        var filter = Builders<Chat>.Filter.Eq(c => c.UserId, userId);
        return await _chatCollection.Find(filter).ToListAsync();
    }
    
    public async Task CreateChat(Chat chat)
    {
        await _chatCollection.InsertOneAsync(chat);
    }

    public async Task DeleteChat(string id)
    {
        var filter = Builders<Chat>.Filter.Eq(c => c.Id, id);
        var result = await _chatCollection.DeleteOneAsync(filter);

        if (result.DeletedCount == 0)
        {
            throw new Exception();
        }
    }
}
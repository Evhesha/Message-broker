using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MessageBroker.Server.Models;

public class Chat
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    
    [BsonElement("userId")]
    public string UserId { get; set; }
    
    [BsonElement("chatName")]
    public string ChatName { get; set; }

    [BsonElement("messages")]
    public List<Message>? Messages { get; set; }
}
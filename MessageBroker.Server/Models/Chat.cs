using MongoDB.Bson.Serialization.Attributes;

namespace MessageBroker.Server.Models;

public class Chat
{
    [BsonId]
    public string Id { get; set; }

    [BsonElement("messages")]
    public List<Message> Messages { get; set; }
}
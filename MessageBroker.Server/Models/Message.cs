using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MessageBroker.Server.Models;

public class Message
{
    [BsonId]
    [BsonGuidRepresentation(GuidRepresentation.Standard)]
    public Guid Id { get; set; }
    
    [BsonElement("userMessage")]
    public required string UserMessage { get; set; }
    
    [BsonElement("botResponse")]
    public required string BotResponse { get; set; }
    
    [BsonElement("date")]
    public required DateTime Date { get; set; } = DateTime.UtcNow;
}
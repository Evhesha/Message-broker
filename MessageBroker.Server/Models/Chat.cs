using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MessageBroker.Server.Models;

public class Chat
{
    [BsonId]
    [BsonGuidRepresentation(GuidRepresentation.Standard)]
    public Guid Id { get; set; }
    
    [BsonElement("name")]
    public string Name { get; set; } = string.Empty;
    
    [BsonElement("date")]
    public DateTime Date { get; set; }
}
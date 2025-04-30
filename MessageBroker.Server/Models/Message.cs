using MongoDB.Bson.Serialization.Attributes;

namespace MessageBroker.Server.Models;

public class Message
{
    [BsonElement("type")]
    public string Type { get; set; } 

    [BsonElement("text")]
    public string Text { get; set; } 

    [BsonElement("date")]
    public DateTime Date { get; set; }
}
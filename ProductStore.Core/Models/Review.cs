using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace ProductStore.Core.Models
{
    public class Review
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } = ObjectId.GenerateNewId().ToString();
        public string CustomerId { get; set; }
        public string ProductId { get; set; }
        public string Text { get; set; }
        public int Rate { get; set; }
    }
}

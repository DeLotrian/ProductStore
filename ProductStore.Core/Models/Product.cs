using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace ProductStore.Core.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } = ObjectId.GenerateNewId().ToString();
        public string Name { get; set; }
        public string CategoryId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public List<Review>? Reviews { get; set; } = new List<Review>();
    }
}

using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace ProductStore.Core.Models
{
    public class CategoryShort
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }
        public string Name { get; set; }
    }
}

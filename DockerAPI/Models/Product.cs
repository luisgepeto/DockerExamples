using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace DockerAPI.Models
{
public class Product
    {
        public ObjectId Id {get; set;}
        [BsonElement("productId")]
        public int ProductId { get; set; }
        [BsonElement("productName")]
        public string ProductName { get; set; }
        [BsonElement("price")]
        public int Price { get; set; }
        [BsonElement("category")]
        public string Category { get; set; }
    }
}
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StoreBK.Models
{
    public class Shop{
        [BsonId]
        public string ShopId { get; set; }
        public string ShopName { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Status { get; set; }
    }
}
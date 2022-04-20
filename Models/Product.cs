using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StoreBK.Models
{
    public class Product{
        [BsonId]
        public string ProductId { get; set; } 
        public string ShopId { get; set; } 
        public string ProductName { get; set; }
        public int UnitPrice { get; set; }
        public string UnitOfMeasure { get; set; }
        public string ProoductCategory { get; set; }
        public string ProoductImage { get; set; }
        public string ProoductDescription { get; set; }
        public string Status { get; set; }
    }}
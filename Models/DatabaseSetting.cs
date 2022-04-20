using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace StoreBK.Models
{
    public class DatabaseSetting : IDatabaseSetting
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string ShopCollection { get; set; }
        public string ProductCollection { get; set; }
    }
    public interface IDatabaseSetting
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string ShopCollection { get; set; }
        string ProductCollection { get; set; }
    }
}
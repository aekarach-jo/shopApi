using StoreBK.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace StoreBK.Services
{
    public class ShopService
    {
        public readonly IMongoCollection<Shop> _shops;
        public ShopService(DatabaseSetting settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            var filter = Builders<Shop>.Filter.Where(settings=> settings.Status == "Open");
            _shops = database.GetCollection<Shop>(settings.ShopCollection);
        }

        public List<Shop> GetAllShop() => _shops.Find(shop => shop.Status == "Open").ToList();
        public List<Shop> GetAllShopForApi() => _shops.Find(shop => true).ToList();

        public Shop GetShopById(string shopId) => _shops.Find<Shop>(shop => shop.ShopId == shopId).FirstOrDefault();

        public Shop CreateShop(Shop shop)
        {
            _shops.InsertOne(shop);
            return shop;
        }
        public void EditShop(string shopId, Shop shopBody) => _shops.ReplaceOne(shops => shops.ShopId == shopId, shopBody);
        public void DeleteShop(string shopId, Shop shopBody) => _shops.ReplaceOne(shops => shops.ShopId == shopId, shopBody);    }
}

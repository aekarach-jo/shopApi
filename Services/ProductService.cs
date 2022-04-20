using StoreBK.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace StoreBK.Services
{
    public class ProductService
    {
        public readonly IMongoCollection<Product> _products;
        public ProductService(DatabaseSetting settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            var filter = Builders<Shop>.Filter.Where(settings=> settings.Status == "Open");
            _products = database.GetCollection<Product>(settings.ProductCollection);
        }

        public List<Product> GetAllProduct() => _products.Find(product => product.Status == "Open").ToList();
        public List<Product> GetAllProductForApi() => _products.Find(product => true).ToList();

        public Product GetProductById(string productId) => _products.Find<Product>(product => product.ProductId == productId).FirstOrDefault();

        public Product CreateProduct(Product product)
        {
            _products.InsertOne(product);
            return product;
        }
        public void EditProduct(string productId, Product productBody) => _products.ReplaceOne(products => products.ProductId == productId, productBody);
        public void DeleteProduct(string productId, Product productBody) => _products.ReplaceOne(products => products.ProductId == productId, productBody);    }
}

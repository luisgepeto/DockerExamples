using System.Collections.Generic;
using MongoDB.Driver;

namespace DockerAPI.Models
{
    public class DbContext
    {
        IMongoDatabase _db;
 
        public DbContext(DbContextConfiguration config)
        {
            var client = new MongoClient(config.ConnectionString);            
            _db = client.GetDatabase("EmployeeDb");      
        }
 
        public IEnumerable<Product> GetProducts()
        {
            return _db.GetCollection<Product>("Products").AsQueryable();
        }
 
 
        public Product GetProduct(int productId)
        {
            var filter = Builders<Product>.Filter.Eq("ProductId", productId);            
            return _db.GetCollection<Product>("Products").Find(filter).FirstOrDefault();
        }
 
        public Product Create(Product p)
        {
            _db.GetCollection<Product>("Products").InsertOne(p);
            return p;
        }
 
        public void Update(int productId,Product p)
        {
            var filter = Builders<Product>.Filter.Eq("ProductId", productId);                        
            var update = Builders<Product>.Update
                                .Set("ProductId", p.ProductId)
                                .Set("ProductName", p.ProductName)
                                .Set("Price", p.Price)
                                .Set("Category", p.Category);
            _db.GetCollection<Product>("Products").UpdateOne(filter,update);
        }
        public void Remove(int productId)
        {
            var filter = Builders<Product>.Filter.Eq("ProductId", productId);            
            var operation = _db.GetCollection<Product>("Products").DeleteOne(filter);            
        }
    }
}
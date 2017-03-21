using System.Collections.Generic;
using MongoDB.Driver;
using System.Linq;

namespace DockerAPI.Models
{
    public class DbContext
    {
        IMongoDatabase _db;
 
        public DbContext(DbContextConfiguration config)
        {
            var client = new MongoClient(config.ConnectionString);            
            _db = client.GetDatabase("docker");      
        }
 
        public IEnumerable<Product> GetProducts()
        {
            return _db.GetCollection<Product>("products").AsQueryable();
        }
 
 
        public Product GetProduct(int productId)
        {
            var filter = Builders<Product>.Filter.Eq("productId", productId);            
            return _db.GetCollection<Product>("products").Find(filter).FirstOrDefault();
        }
 
        public Product Create(Product p)
        {
            var lastProductId =GetProducts().Select(pr => pr.ProductId).OrderByDescending(pr => pr).FirstOrDefault();
            p.ProductId=lastProductId+1;
            _db.GetCollection<Product>("products").InsertOne(p);
            return p;
        }
 
        public void Update(int productId,Product p)
        {
            var filter = Builders<Product>.Filter.Eq("productId", productId);                        
            var update = Builders<Product>.Update                                
                                .Set("productName", p.ProductName)
                                .Set("price", p.Price)
                                .Set("category", p.Category);
            _db.GetCollection<Product>("products").UpdateOne(filter,update);
        }
        public void Remove(int productId)
        {
            var filter = Builders<Product>.Filter.Eq("productId", productId);            
            var operation = _db.GetCollection<Product>("products").DeleteOne(filter);            
        }
    }
}
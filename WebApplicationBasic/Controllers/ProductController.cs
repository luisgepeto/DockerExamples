using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using WebApplicationBasic.Models;

namespace WebApplicationBasic.Controllers{
    [Route("api/Product")]
    public class ProductAPIController : Controller
    {
        DataAccess objds;
 
        public ProductAPIController(DataAccess d)
        {
            objds = d; 
        }
 
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return objds.GetProducts();
        }
        [HttpGet("{id:length(24)}")]
        public IActionResult Get(string id)
        {
            var product = objds.GetProduct(new ObjectId(id));
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
 
        [HttpPost]
        public IActionResult Post([FromBody]Product p)
        {
            objds.Create(p);
            return Ok(p);
        }
        [HttpPut("{id:length(24)}")]
        public IActionResult Put(string id, [FromBody]Product p)
        {
            var recId = new ObjectId(id);
            var product = objds.GetProduct(recId);
            if (product == null)
            {
                return NotFound();
            }
            
            objds.Update(recId, p);
            return Ok();
        }
 
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var product = objds.GetProduct(new ObjectId(id));
            if (product == null)
            {
                return NotFound();
            }
 
            objds.Remove(product.Id);
            return Ok();
        }
    }
}
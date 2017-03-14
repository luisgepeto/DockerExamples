using System.Collections.Generic;
using DockerAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DockerAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private DbContext _context;
        public ProductsController(DbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _context.GetProducts();
        }

        [HttpGet("{productId}")]
        public IActionResult Get(int productId)
        {
            var product = _context.GetProduct(productId);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Product product)
        {
            _context.Create(product);
            return Ok(product);
        }

        [HttpPut("{productId}")]
        public IActionResult Put(int productId, [FromBody]Product newProduct)
        {
            var product = _context.GetProduct(productId);
            if (product == null)
            {
                return NotFound();
            }            
            _context.Update(productId, newProduct);
            var updatedProduct = _context.GetProduct(newProduct.ProductId);
            return Ok(updatedProduct);
        }

        [HttpDelete("{productId}")]
        public IActionResult Delete(int productId)
        {
            var product = _context.GetProduct(productId);
            if (product == null)
            {
                return NotFound();
            } 
            _context.Remove(productId);
            return Ok();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DockerWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace DockerWeb.Controllers
{
    public class ProductController : Controller
    {
        private DataAccess _da;
        public ProductController(DataAccess da)
        {
            _da = da;
        }
        public IActionResult Index()
        {
            return View(_da.Get());
        }

        public IActionResult Details(int id)
        {
            return View(_da.Get(id));
        }

        public IActionResult Edit(int id)
        {
            var product = _da.Get(id);
            if(id == 0) product = new ProductViewModel();            
            return View(product);
        }

        [HttpPost]
        public IActionResult Save(ProductViewModel product)
        {
            var productId = product.ProductId;
            if (productId == 0)
            {
                productId = _da.Create(product).ProductId;
            }
            else
            {
                _da.Update(product);
            }            
            return RedirectToAction("Details", new { id = productId });
        }

        public IActionResult Delete(int id)
        {
            _da.Delete(id);            
            return RedirectToAction("Index");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace DockerWeb.Models{
    public class DataAccess{
        private HttpClient _client;
        public DataAccess(ApiConfiguration config)
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(config.ApiUrl);
        }
        public List<ProductViewModel> Get(){
            var all= _client.GetAsync("api/products").Result;
            return new List<ProductViewModel>();
        }

        public ProductViewModel Get(int id){
            var all= _client.GetAsync("api/products/"+ id).Result;
            return new ProductViewModel();
        }

        public ProductViewModel Create(ProductViewModel product){
            //var all= _client.PostAsJsonAsync("api/products", product).Result;

            return new ProductViewModel();
        }

        public ProductViewModel Update(ProductViewModel product){
            //var all= _client.PostAsJsonAsync("api/products/"+ product.ProductId, product).Result;
            return new ProductViewModel();
        }

        public ProductViewModel Delete(int id){
            var all= _client.DeleteAsync("api/products/"+ id).Result;
            return new ProductViewModel();
        }

    }
}
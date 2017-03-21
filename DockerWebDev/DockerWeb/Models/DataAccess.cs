using System;
using System.Collections.Generic;
using System.Net.Http;
using  Newtonsoft.Json;
using System.Text;

namespace DockerWeb.Models{
    public class DataAccess{
        private HttpClient _client;
        public DataAccess(ApiConfiguration config)
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://"+config.ApiUrl+":8080/");
        }
        public List<ProductViewModel> Get(){
            var response = _client.GetAsync("api/products").Result;            
            var result = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<List<ProductViewModel>>(result);          
        }

        public ProductViewModel Get(int id){
            var response= _client.GetAsync("api/products/"+ id).Result;
            var result = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<ProductViewModel>(result);          
        }

        public ProductViewModel Create(ProductViewModel product){
            var jsonString = JsonConvert.SerializeObject(product);
            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json"); 
            var response= _client.PostAsync("api/products", httpContent).Result;
            var result = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<ProductViewModel>(result);          
        }

        public ProductViewModel Update(ProductViewModel product){
            var jsonString = JsonConvert.SerializeObject(product);
            var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json"); 
            var response= _client.PutAsync("api/products/"+product.ProductId, httpContent).Result;
            var result = response.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<ProductViewModel>(result);  
        }

        public void Delete(int id){
            var all= _client.DeleteAsync("api/products/"+ id).Result;            
        }

    }
}
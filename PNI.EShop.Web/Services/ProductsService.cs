using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PNI.EShop.Web.Models;

namespace PNI.EShop.Web.Services
{
    public class ProductsService : IProductsService
    {
        public async Task<ProductViewModel[]> ListOfAllProductsAsync(){

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8889");

                var response = await client.GetAsync(new Uri("/Products", UriKind.Relative));
                var jsonResponse = await response.Content.ReadAsStringAsync();

                var products = JsonConvert.DeserializeObject<ProductViewModel[]>(jsonResponse);

                return products;
            }
        }

        public async Task<ProductViewModel> ProductByIdAsync(Guid id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8889");

                var response = await client.GetAsync(new Uri($"Products/{id}", UriKind.Relative));
                var jsonResponse = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<ProductViewModel>(jsonResponse);
            }
        }
    }
}
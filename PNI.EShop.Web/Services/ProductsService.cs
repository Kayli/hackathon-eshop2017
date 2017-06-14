using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PNI.EShop.Core.ProductCatalog.DataAccess;
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

                var products = JsonConvert.DeserializeObject<ProductDto[]>(jsonResponse);

                return products.Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Color = p.Model.Color,
                    Type = p.Model.Type,
                    CreatedAt = p.CreatedAt.ToString(),
                    UpdatedAt = p.ModifiedAt.ToString()
                }).ToArray();
                
            }
        }

        public async Task<ProductViewModel> ProductByIdAsync(Guid id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8889");

                var response = await client.GetAsync(new Uri($"Products/{id}", UriKind.Relative));
                var jsonResponse = await response.Content.ReadAsStringAsync();

                var product = JsonConvert.DeserializeObject<ProductDto>(jsonResponse);

                return new ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Color = product.Model.Color,
                    Type = product.Model.Type,
                    CreatedAt = product.CreatedAt.ToString(),
                    UpdatedAt = product.ModifiedAt.ToString()
                };
            }
        }
    }
}
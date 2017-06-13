using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PNI.EShop.Web.Models;

namespace PNI.EShop.Web.Services
{
    public class ProductsService : IProductsService
    {
        private readonly ConcurrentBag<ProductViewModel> _products;

        public ProductsService(IEnumerable<ProductViewModel> products)
        {
            _products = new ConcurrentBag<ProductViewModel>(products);
        }
        
        public Task<ProductViewModel[]> ListOfAllProductsAsync(){
            
            return Task.FromResult(_products.ToArray());
        }

        public Task<ProductViewModel> ProductByIdAsync(Guid id)
        {
            return Task.FromResult(_products.FirstOrDefault(p => p.Id == id));
        }
    }
}
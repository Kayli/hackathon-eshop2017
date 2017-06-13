using System.Collections.Concurrent;
using System.Collections.Generic;
using PNI.EShop.UI.Models;

namespace PNI.EShop.UI.Services
{
    public class ProductsService : IProductsService
    {
        private readonly ConcurrentBag<ProductViewModel> _products;

        public ProductsService(IEnumerable<ProductViewModel> products)
        {
            _products = new ConcurrentBag<ProductViewModel>(products);
        }
        
        public ProductViewModel[] ListOfAllProducts(){
            
            return _products.ToArray();
        }
    }
}
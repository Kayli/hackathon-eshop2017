using System.Collections.Generic;
using PNI.EShop.Core.Product;

namespace PNI.EShop.Core.Services
{
    public interface IProductManagerService
    {
        IEnumerable<Product.Product> RetrieveAllProducts();
        Product.Product ProductById(ProductId id);
    }
}
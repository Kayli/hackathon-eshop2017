using System.Collections.Generic;
using PNI.EShop.Core.ProductCatalog.Data;

namespace PNI.EShop.Core.ProductCatalog
{
    public interface IProductManagerService
    {
        IEnumerable<Product> RetrieveAllProducts();
        Product ProductById(ProductId id);
    }
}
using System.Collections;

namespace PNI.EShop.Service.ProductManager
{
    public interface IProductManagerService
    {
        IEnumerable<Product> RetrieveAllProducts();
    }
}
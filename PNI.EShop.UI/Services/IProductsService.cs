using PNI.EShop.UI.Models;

namespace PNI.EShop.UI.Services
{
    public interface IProductsService
    {
        ProductViewModel[] ListOfAllProducts();
    }
}
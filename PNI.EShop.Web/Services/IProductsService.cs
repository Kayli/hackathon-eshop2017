using PNI.EShop.Web.Models;

namespace PNI.EShop.Web.Services
{
    public interface IProductsService
    {
        ProductViewModel[] ListOfAllProducts();
    }
}
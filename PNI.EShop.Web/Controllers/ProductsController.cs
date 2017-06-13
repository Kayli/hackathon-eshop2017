using Microsoft.AspNetCore.Mvc;
using PNI.EShop.Web.Services;

namespace PNI.EShop.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        public IActionResult Index()
        {
            return View(_productsService.ListOfAllProducts());
        }
    }
}
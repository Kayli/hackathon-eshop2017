using Microsoft.AspNetCore.Mvc;
using PNI.EShop.UI.Services;

namespace PNI.EShop.UI.Controllers
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
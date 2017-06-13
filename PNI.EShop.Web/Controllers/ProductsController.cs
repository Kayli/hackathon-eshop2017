using System;
using System.Threading.Tasks;
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

        public async Task<IActionResult> Index()
        {
            return View(await _productsService.ListOfAllProductsAsync());
        }

        public async Task<IActionResult> Detail(Guid id)
        {
            return View(await _productsService.ProductByIdAsync(id));
        }
    }
}
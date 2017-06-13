using Microsoft.AspNetCore.Mvc;

namespace PNI.EShop.UI.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
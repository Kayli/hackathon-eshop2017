using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PNI.EShop.Core;

namespace PNI.EShop.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEventStore _eventStore;

        public HomeController(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            _eventStore.Publish(new TestEvent());

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}

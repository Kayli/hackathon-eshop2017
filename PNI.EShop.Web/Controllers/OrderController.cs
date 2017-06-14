using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PNI.EShop.Web.Models;

namespace PNI.EShop.Web.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        // GET: Order/Confirmation
        public ActionResult Confirmation(OrderViewModel orderViewModel)
        {
            ViewBag.OrderStatus = orderViewModel.OrderStatus;
            return View();
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderViewModel orderViewModel)
        {
            try
            {
                // TODO: validate and save
                orderViewModel.OrderStatus = Core.Order.OrderStatus.OrderPlaced;
                return RedirectToAction("Confirmation", "Order", orderViewModel);
            }
            catch
            {
                return View();
            }
        }

    }
}
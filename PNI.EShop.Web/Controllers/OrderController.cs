using Microsoft.AspNetCore.Mvc;
using PNI.EShop.Web.Models;
using System;
using PNI.EShop.Core.Order;

namespace PNI.EShop.Web.Controllers
{
    public class OrderController : Controller
    {
        private static OrderViewModel _tempOrderViewModel;
        private IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: Order
        public ActionResult Index()
        {
            if(_tempOrderViewModel != null)
            {
                return View(_tempOrderViewModel);
            }
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
            _tempOrderViewModel = orderViewModel;
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Index", orderViewModel);
                }

                _orderService.CreateOrder(orderViewModel.ProductId, orderViewModel.Customer);
                orderViewModel.OrderStatus = OrderStatus.OrderPlaced;
                return RedirectToAction("Confirmation", "Order", orderViewModel);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View("Index", orderViewModel);
            }
        }

    }
}
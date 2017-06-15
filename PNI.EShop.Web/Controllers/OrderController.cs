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

   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Guid productId)
        {
            if (_tempOrderViewModel == null)
            {
                OrderViewModel orderViewModel = new OrderViewModel()
                {
                    ProductId = productId
                };
                _tempOrderViewModel = orderViewModel;
            }
            return View(_tempOrderViewModel);
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
        public ActionResult Create(OrderViewModel orderViewModel, Guid productId)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Index", orderViewModel);
                }
                orderViewModel.ProductId = productId;
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
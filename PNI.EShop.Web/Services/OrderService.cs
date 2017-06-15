using PNI.EShop.Core.Order;
using System;
using CoreOrderService = PNI.EShop.Core.Order.OrderService;

namespace PNI.EShop.Web.Services
{
    public class OrderService
    {
        private CoreOrderService _coreOrderService;
        public OrderService(CoreOrderService coreOrderService)
        {
            _coreOrderService = coreOrderService;
        }
        public void CreateOrder(Guid productId, Customer customer)
        {
            _coreOrderService.CreateOrder(productId, customer);
        }
    }
}

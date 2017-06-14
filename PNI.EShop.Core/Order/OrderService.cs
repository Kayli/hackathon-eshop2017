using System;
using PNI.EShop.Core.Services;
using PNI.EShop.Core._Common;

namespace PNI.EShop.Core.Order
{
    public class OrderService : IOrderService
    {
        public void Handle(ProductCreated @event)
        {
            //handle product creation here if required
        }
    }
}
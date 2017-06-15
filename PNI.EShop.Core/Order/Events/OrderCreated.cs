using PNI.EShop.Core._Common;
using System;

namespace PNI.EShop.Core.Order.Events
{
    public class OrderCreated : EventBase
    {
        public long OrderId { get; set; }
        public Guid ProductId { get; set; }
        public Customer Customer { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
    }
}

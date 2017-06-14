using PNI.EShop.Core.Order;
using System;


namespace PNI.EShop.Web.Models
{
    public class OrderViewModel
    {
        public Guid ProductId { get; }
        public Guid OrderId { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public Customer Customer { get; set; }
    }
}

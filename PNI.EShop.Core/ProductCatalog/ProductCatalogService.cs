using System;
using PNI.EShop.Core.Product;
using PNI.EShop.Core._Common;

namespace PNI.EShop.Core.Services
{
    public class ProductCatalogService
    {
        
    }

    public class ProductCreatedEvent : IEvent
    {
        public Guid Id { get; set; }
        public DateTimeOffset Published { get; set; }

        public Guid ProductId { get; set; }
    }
}
using System;

namespace PNI.EShop.Core.ProductCatalog
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
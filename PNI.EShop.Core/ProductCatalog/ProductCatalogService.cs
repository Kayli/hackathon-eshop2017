using System;
using PNI.EShop.Core._Common;
using PNI.EShop.Core.Product;

namespace PNI.EShop.Core.Services
{
    public class ProductCatalogService : IProductCatalogService
    {
        private readonly IEventStore _eventStore;

        public ProductCatalogService(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public void CreateProduct(string name, string description, ModelType type, ColorDefinition color)
        {
            _eventStore.Publish(new ProductCreated
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description,
                Type = type,
                Color = color
            });
        }
    }
}
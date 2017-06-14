using System;
using PNI.EShop.Core.Services;

namespace PNI.EShop.Core.ProductCatalog
{
    public class ProductCatalogService : IProductCatalogService
    {
        private readonly IEventStore _eventStore;

        public ProductCatalogService(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public void CreateProduct(string name, string description, ModelTypeDefinition type, ColorDefinition color)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new EShopException("name can't be empty or whitespace");

            _eventStore.Publish(new ProductCreated
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description,
                Type = type,
                Color = color
            });
        }

        public void Handle(ProductCreated @event)
        {
            //store product in ProductCatalog repository
        }
    }
}
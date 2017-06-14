using System;
using Microsoft.ServiceFabric.Actors;
using PNI.EShop.Core;
using PNI.EShop.Core.ProductCatalog.DataAccess;
using PNI.EShop.Core.Services;
using ProductRepository.Interfaces;

namespace PNI.EShop.Infrastructure.Services
{
    public class ProductCatalogService : IProductCatalogService
    {
        private static readonly ActorId ActorId = new ActorId("EShopProductRepsitory");

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

        public async void Handle(ProductCreated @event)
        {
            var productRepository = ProductRepositoryFactory.GetProductRepository(ActorId);

            var productDto = new ProductDto
            {
                Id = @event.Id,
                Name = @event.Name,
                Description = @event.Description,
                Model = new ProductModelDto
                {
                    Color = @event.Color,
                    Type = @event.Type,
                    CreatedAt = DateTimeOffset.UtcNow,
                    UpdatedAt = DateTimeOffset.UtcNow
                },
                CreatedAt = DateTimeOffset.UtcNow,
                ModifiedAt = DateTimeOffset.UtcNow
            };

            await productRepository.CreateProduct(productDto);
        }
    }
}
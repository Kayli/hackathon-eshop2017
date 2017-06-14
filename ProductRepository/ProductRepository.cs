using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Runtime;
using PNI.EShop.Core.Product;
using PNI.EShop.Core._Common;
using ProductRepository.Interfaces;

namespace ProductRepository
{
    /// <remarks>
    /// This class represents an actor.
    /// Every ActorID maps to an instance of this class.
    /// The StatePersistence attribute determines persistence and replication of actor state:
    ///  - Persisted: State is written to disk and replicated.
    ///  - Volatile: State is kept in memory only and replicated.
    ///  - None: State is kept in memory only and not replicated.
    /// </remarks>
    [StatePersistence(StatePersistence.Persisted)]
    internal class ProductRepository : Actor, IProductRepository
    {
        /// <summary>
        /// Initializes a new instance of ProductRepository
        /// </summary>
        /// <param name="actorService">The Microsoft.ServiceFabric.Actors.Runtime.ActorService that will host this actor instance.</param>
        /// <param name="actorId">The Microsoft.ServiceFabric.Actors.ActorId for this actor instance.</param>
        public ProductRepository(ActorService actorService, ActorId actorId)
            : base(actorService, actorId)
        {
            var i = 1;
        }
        
        /// <summary>
        /// This method is called whenever an actor is activated.
        /// An actor is activated the first time any of its methods are invoked.
        /// </summary>
        protected override async Task OnActivateAsync()
        {
            ActorEventSource.Current.ActorMessage(this, "Actor activated.");

            var state = await StateManager.TryGetStateAsync<IEnumerable<Product>>("products");

            if (!state.HasValue)
            {
                await StateManager.TryAddStateAsync("products", CreateProducts());
            }
        }

        public Task<Product[]> RetrieveAllProductsAsync()
        {
            //return await StateManager.GetStateAsync<Product[]>("products");

            return Task.FromResult(CreateProducts().ToArray());
        }

        public async Task<Product> ProductById(ProductId id)
        {
            return (await StateManager.GetStateAsync<Product[]>("products")).First(p => p.Id == id);
        }

        private static IEnumerable<Product> CreateProducts()
        {
            return new[]
            {
                new Product(
                    new ProductId(Guid.Parse("89707fc0-1493-4899-a062-e37127ec497b")),
                    new StringValue("Black Box"),
                    new StringValue("A simple black box"),
                    new ProductModel(
                        new ColorValue(ColorDefinition.Black),
                        new ModelType(ModelTypeDefinition.Box),
                        new DateValue(DateTimeOffset.Parse("Jan 24, 1975 15:00z")),
                        new DateValue(DateTimeOffset.UtcNow)),
                    new DateValue(DateTimeOffset.Parse("Jan 24, 1975 15:00z")),
                    new DateValue(DateTimeOffset.UtcNow)),
                new Product(
                    new ProductId(Guid.Parse("5a19ff97-8095-4d43-8d30-26751851a6fe")),
                    new StringValue("White Box"),
                    new StringValue("A simple white box"),
                    new ProductModel(
                        new ColorValue(ColorDefinition.White),
                        new ModelType(ModelTypeDefinition.Box),
                        new DateValue(DateTimeOffset.Parse("Jan 24, 1975 15:00z")),
                        new DateValue(DateTimeOffset.UtcNow)),
                    new DateValue(DateTimeOffset.Parse("Jan 24, 1975 15:00z")),
                    new DateValue(DateTimeOffset.UtcNow)),
                new Product(
                    new ProductId(Guid.Parse("4b4480b3-e368-4f01-931c-67c52eee914a")),
                    new StringValue("Red Cone"),
                    new StringValue("A simple red cone"),
                    new ProductModel(
                        new ColorValue(ColorDefinition.Red),
                        new ModelType(ModelTypeDefinition.Cone),
                        new DateValue(DateTimeOffset.Parse("Jan 24, 1975 15:00z")),
                        new DateValue(DateTimeOffset.UtcNow)),
                    new DateValue(DateTimeOffset.Parse("Jan 24, 1975 15:00z")),
                    new DateValue(DateTimeOffset.UtcNow)),
                new Product(
                    new ProductId(Guid.Parse("718e5ba7-b31c-4655-849b-880948d83cba")),
                    new StringValue("Green Sphere"),
                    new StringValue("A simple green sphere"),
                    new ProductModel(
                        new ColorValue(ColorDefinition.Green),
                        new ModelType(ModelTypeDefinition.Sphere),
                        new DateValue(DateTimeOffset.Parse("Jan 24, 1975 15:00z")),
                        new DateValue(DateTimeOffset.UtcNow)),
                    new DateValue(DateTimeOffset.Parse("Jan 24, 1975 15:00z")),
                    new DateValue(DateTimeOffset.UtcNow)),
                new Product(
                    new ProductId(Guid.Parse("5803710e-92a9-4b08-8788-fccf8a9c8e4a")),
                    new StringValue("Black Box"),
                    new StringValue("A simple black box"),
                    new ProductModel(
                        new ColorValue(ColorDefinition.Red),
                        new ModelType(ModelTypeDefinition.Box),
                        new DateValue(DateTimeOffset.Parse("Jan 24, 1975 15:00z")),
                        new DateValue(DateTimeOffset.UtcNow)),
                    new DateValue(DateTimeOffset.Parse("Jan 24, 1975 15:00z")),
                    new DateValue(DateTimeOffset.UtcNow))
            };

        }
    }
}

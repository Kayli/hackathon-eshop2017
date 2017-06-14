using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Runtime;
using PNI.EShop.Core.ProductCatalog.DataAccess;
using ProductActor.Interfaces;
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
        }
        
        /// <summary>
        /// This method is called whenever an actor is activated.
        /// An actor is activated the first time any of its methods are invoked.
        /// </summary>
        protected override Task OnActivateAsync()
        {
            ActorEventSource.Current.ActorMessage(this, "Actor activated.");

            return Task.FromResult(true);
        }

        public async Task<ProductDto[]> RetrieveAllProducts()
        {
            var productIds = await StateManager.TryGetStateAsync<List<Guid>>("products");
            var products = new List<ProductDto>();

            if (!productIds.HasValue) return products.ToArray();

            var productList = productIds.Value.Select(ProductById).ToArray();

            Task.WaitAll(productList);

            products.AddRange(productList.Select(task => task.Result));

            return products.ToArray();
        }
        
        public Task<ProductDto> ProductById(Guid id)
        {
            var productActor = ProductActorFactory.GetProductActor(new ActorId(id));

            return productActor.RetrieveProduct();
        }

        public async Task CreateProduct(ProductDto product)
        {
            var productActor = ProductActorFactory.GetProductActor(new ActorId(product.Id));

            await productActor.CreateProduct(product);

            await AddIdToState(product.Id);
        }

        private async Task AddIdToState(Guid id)
        {
            var state = await StateManager.TryGetStateAsync<List<Guid>>("products");
            if (state.HasValue)
            {
                state.Value.Add(id);

                await StateManager.AddOrUpdateStateAsync("products", state.Value, (key, products) => products);

                return;
            }

            var newState = new List<Guid> {id};

            await StateManager.AddStateAsync("products", newState);
        }
    }
}

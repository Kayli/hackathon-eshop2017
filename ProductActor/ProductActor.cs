using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Runtime;
using PNI.EShop.Core.ProductCatalog.DataAccess;
using ProductActor.Interfaces;

namespace ProductActor
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
    internal class ProductActor : Actor, IProductActor
    {
        /// <summary>
        /// Initializes a new instance of ProductActor
        /// </summary>
        /// <param name="actorService">The Microsoft.ServiceFabric.Actors.Runtime.ActorService that will host this actor instance.</param>
        /// <param name="actorId">The Microsoft.ServiceFabric.Actors.ActorId for this actor instance.</param>
        public ProductActor(ActorService actorService, ActorId actorId)
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

        public Task CreateProduct(ProductDto product)
        {
            var ev = GetEvent<IProductEvents>();
            ev.ProductCreated(product.Id);

            return StateManager.AddOrUpdateStateAsync("product", product, (key, value) => value);
        }

        public async Task<ProductDto> RetrieveProduct()
        {
            var product = await StateManager.TryGetStateAsync<ProductDto>("product");
            return product.HasValue ? product.Value : null;
        }
    }
}

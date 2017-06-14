using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;
using PNI.EShop.Core.ProductCatalog.DataAccess;

namespace ProductActor.Interfaces
{
    /// <summary>
    /// This interface defines the methods exposed by an actor.
    /// Clients use this interface to interact with the actor that implements it.
    /// </summary>
    public interface IProductActor : IActor, IActorEventPublisher<IProductEvents>
    {
        Task CreateProduct(ProductDto product);
        Task<ProductDto> RetrieveProduct();
    }
}

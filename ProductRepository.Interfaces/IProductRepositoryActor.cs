using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;
using PNI.EShop.Core.Product;

namespace ProductRepository.Interfaces
{
    /// <summary>
    /// This interface defines the methods exposed by an actor.
    /// Clients use this interface to interact with the actor that implements it.
    /// </summary>
    public interface IProductRepositoryActor : IActor
    {
        Task<Product[]> RetrieveAllProductsAsync();
        Task<Product> ProductById(ProductId id);
    }
}

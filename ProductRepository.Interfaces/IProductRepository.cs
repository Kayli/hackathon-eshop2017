using System;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Actors;
using PNI.EShop.Core.ProductCatalog.DataAccess;

namespace ProductRepository.Interfaces
{
    /// <summary>
    /// This interface defines the methods exposed by an actor.
    /// Clients use this interface to interact with the actor that implements it.
    /// </summary>
    public interface IProductRepository : IActor
    {
        Task<ProductDto[]> RetrieveAllProductsAsync();
        Task<ProductDto> ProductById(Guid id);
    }
}

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ServiceFabric.Actors;
using PNI.EShop.Core.ProductCatalog.DataAccess;
using ProductRepository.Interfaces;

namespace PNI.EShop.API.Controllers
{
    [Produces("application/json")]
    [Route("Products")]
    public class ProductsController : Controller
    {
        private static readonly ActorId ActorId = new ActorId("EShopProductRepsitory");
        
        [HttpGet]
        [Route("")]
        public Task<ProductDto[]> Products()
        {
            var productRepository = ProductRepositoryFactory.GetProductRepository(ActorId);

            try
            {
                return productRepository.RetrieveAllProducts();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet]
        [Route("{id}")]
        public Task<ProductDto> Product(Guid id)
        {
            return ProductRepositoryFactory.GetProductRepository(ActorId).ProductById(id);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ServiceBus.Messaging;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;
using PNI.EShop.API.Models;
using PNI.EShop.Core.Services;
using PNI.EShop.Core._Common;
using ProductRepository.Interfaces;

namespace PNI.EShop.API.Controllers
{
    [Serializable]
    public class RequestAllDataMessage
    {
        public bool SendAllProducts => true;
    }

    [Produces("application/json")]
    [Route("Products")]
    public class ProductsController : Controller
    {
        private static readonly ActorId ActorId = ActorId.CreateRandom();

        [HttpGet]
        [Route("")]
        public async Task<ProductDto[]> Products()
        {
            var client =
                TopicClient.CreateFromConnectionString(
                    ConfigurationManager.AppSettings["Microsoft.ServiceBus.ConnectionString"], "productrequests");

            var message = new RequestAllDataMessage();
            client.Send(new BrokeredMessage(message)
            {
                ContentType = message.GetType().ToString()
            });
            
            var repo = ActorProxy.Create<IProductRepositoryActor>(ActorId, new Uri("fabric:/PNI.Services/ProductRepositoryActorService"));

            var products = await repo.RetrieveAllProductsAsync();

            return products.Select(p => new ProductDto
                                            {
                                                Id = p.Id.Id,
                                                Name = p.Name.ToString(),
                                                Color = p.Model.Color.Color,
                                                Type = p.Model.Type.ModelTypeDefinition,
                                                CreatedAt = p.CreatedAt.Date,
                                                UpdatedAt = p.ModifiedAt.Date
                                            }).ToArray();
        }

        [HttpGet]
        [Route("{id}")]
        public Task<ProductDto> Product(Guid id)
        {
            return Task.FromResult(CreateProducts().First(p => p.Id == id));
        }

        private static IEnumerable<ProductDto> CreateProducts()
        {
            return new[]
            {
                new ProductDto { Id = Guid.Parse("89707fc0-1493-4899-a062-e37127ec497b"), Color = ColorDefinition.Black, Type = ModelTypeDefinition.Box, Name = "Black Box"},
                new ProductDto { Id = Guid.Parse("5a19ff97-8095-4d43-8d30-26751851a6fe"), Color = ColorDefinition.White, Type = ModelTypeDefinition.Box, Name = "White Box"},
                new ProductDto { Id = Guid.Parse("4b4480b3-e368-4f01-931c-67c52eee914a"), Color = ColorDefinition.Red, Type = ModelTypeDefinition.Cone, Name = "Red Cone"},
                new ProductDto { Id = Guid.Parse("718e5ba7-b31c-4655-849b-880948d83cba"), Color = ColorDefinition.Blue, Type = ModelTypeDefinition.Cylinder, Name = "Red Cylinder"},
                new ProductDto { Id = Guid.Parse("5803710e-92a9-4b08-8788-fccf8a9c8e4a"), Color = ColorDefinition.Green, Type = ModelTypeDefinition.Sphere, Name = "Green Sphere"},
            };

        }
    }
}
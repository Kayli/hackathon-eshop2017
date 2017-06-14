using System;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;

namespace ProductRepository.Interfaces
{
    public class ProductRepositoryFactory
    {
        private static readonly Uri RepsitoryActorUrl = new Uri("fabric:/PNI.Services/ProductRepositoryActorService");

        public static IProductRepository GetProductRepository(ActorId actorId)
        {
            return ActorProxy.Create<IProductRepository>(actorId, RepsitoryActorUrl);
        }
    }
}
using System;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;

namespace ProductActor.Interfaces
{
    public class ProductActorFactory
    {
        private static readonly Uri RepsitoryActorUrl = new Uri("fabric:/PNI.Services/ProductActorService");

        public static IProductActor GetProductActor(ActorId productId)
        {
            return ActorProxy.Create<IProductActor>(productId, RepsitoryActorUrl);
        }
    }
}
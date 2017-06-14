using System;
using Microsoft.ServiceFabric.Actors;

namespace ProductActor.Interfaces
{
    public interface IProductEvents : IActorEvents
    {
        void ProductCreated(Guid productId);
    }
}
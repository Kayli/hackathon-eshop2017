using System;
using ProductActor.Interfaces;

namespace ProductActor
{
    public class ProductEventsHandler : IProductEvents
    {
        public void ProductCreated(Guid productId)
        {
            throw new NotImplementedException();
        }
    }
}
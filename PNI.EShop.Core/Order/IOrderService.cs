using PNI.EShop.Core.Services;
using PNI.EShop.Core._Common;
using System;

namespace PNI.EShop.Core.Order
{
    public interface IOrderService : IHandlesEvent<ProductCreated>
    {
        void CreateOrder(Guid productId, Customer customer);
    }
}
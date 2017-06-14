using PNI.EShop.Core.Services;
using PNI.EShop.Core._Common;

namespace PNI.EShop.Core.Order
{
    public interface IOrderService : IEventHandler, IHandlesEvent<ProductCreated>
    {

    }
}
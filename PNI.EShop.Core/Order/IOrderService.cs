using PNI.EShop.Core._Common;

namespace PNI.EShop.Core.Order
{
    public interface IOrderService : IEventHandler, IHandlesEvent<TestEvent>
    {

    }
}
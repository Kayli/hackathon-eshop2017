using System;

namespace PNI.EShop.Core
{
    public interface IEventStore
    {
        void Publish(IEvent @event);
        void Subscribe(Func<IEventHandler> eventHandlerFactory);
    }
}
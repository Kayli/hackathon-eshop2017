using System;

namespace PNI.EShop.Core._Common
{
    public interface IEventStore
    {
        void Publish(IEvent @event);
        void Subscribe(Func<IEventHandler> eventHandlerFactory);
    }
}
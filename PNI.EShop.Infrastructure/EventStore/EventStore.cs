using System;
using System.Collections.Generic;
using System.Text;
using PNI.EShop.Core;
using System.Collections.Concurrent;
using System.Reflection;
using System.Linq;

namespace PNI.EShop.Infrastructure.EventStore
{
    public class EventStore : IEventStore
    {
        private object _syncRoot = new object();
        private ConcurrentDictionary<Guid, IEvent> _events = new ConcurrentDictionary<Guid, IEvent>();
        private ConcurrentBag<Func<IEventHandler>> _eventHandlerFactories = new ConcurrentBag<Func<IEventHandler>>();

        public void Publish(IEvent @event)
        {
            lock (_syncRoot)
            {
                var res = _events.TryAdd(@event.Id, @event);
                if(!res) throw new Exception("Something went wrong while trying to add event to collection");
            }

            var eventType = @event.GetType();
            foreach (var eventHandlerFactory in _eventHandlerFactories)
            {
                var eventHandler = eventHandlerFactory();
                var allHandleMethods = eventHandler.GetType().GetTypeInfo().GetMethods().Where(x => x.Name == "Handle");
                var eventHandleMethods = allHandleMethods.Where(x => x.GetParameters().Any(y => y.ParameterType == eventType)).ToArray();
                foreach (var eventHandleMethod in eventHandleMethods)
                    eventHandleMethod.Invoke(eventHandler, new[] { @event } );
            }
        }

        public void Subscribe(Func<IEventHandler> eventHandlerFactory)
        {
            _eventHandlerFactories.Add(eventHandlerFactory);
        }
    }
}
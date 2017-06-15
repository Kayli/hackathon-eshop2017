using System;

namespace PNI.EShop.Core._Common
{
    public abstract class EventBase : IEvent
    {
        public EventBase()
        {
            EventId = Guid.NewGuid();
            EventPublished = DateTimeOffset.Now;
        }

        public Guid            EventId { get; set; }
        public DateTimeOffset  EventPublished { get; set; }
    }
}
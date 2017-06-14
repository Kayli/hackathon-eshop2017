using System;

namespace PNI.EShop.Core
{
    public interface IEvent
    {
        Guid           EventId { get; }
        DateTimeOffset EventPublished { get; }
    }
}
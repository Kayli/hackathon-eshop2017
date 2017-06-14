using System;

namespace PNI.EShop.Core._Common
{
    public interface IEvent
    {
        Guid           EventId { get; }
        DateTimeOffset EventPublished { get; }
    }
}
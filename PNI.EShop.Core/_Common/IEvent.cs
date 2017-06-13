using System;

namespace PNI.EShop.Core
{
    public interface IEvent
    {
        Guid            Id { get; }
        DateTimeOffset  Published { get; }
    }

    public class TestEvent : IEvent
    {
        public Guid           Id { get; set; }
        public DateTimeOffset Published { get; set; }
    }
}
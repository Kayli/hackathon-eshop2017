namespace PNI.EShop.Core._Common
{
    public interface IHandlesEvent<TEvent> : IEventHandler where TEvent : IEvent
    {
        void Handle(TEvent @event);
    }

    public interface IEventHandler { }
}
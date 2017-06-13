namespace PNI.DDD.Core
{
    public interface IEntity<out TId>
    {
        IIdentity<TId> Id { get; }
    }
}
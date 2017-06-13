namespace PNI.DDD.Core
{
    public interface IIdentity<out TId>
    {
        TId Id { get; }
    }
}
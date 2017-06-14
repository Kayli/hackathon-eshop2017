namespace PNI.EShop.Core
{
    public interface IEntity<out TId>
    {
        IIdentity<TId> Id { get; }
    }
}
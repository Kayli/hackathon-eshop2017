namespace PNI.EShop.Core._Common
{
    public interface IEntity<out TId>
    {
        IIdentity<TId> Id { get; }
    }
}
namespace PNI.EShop.Core
{
    public interface IIdentity<out TId>
    {
        TId Id { get; }
    }
}
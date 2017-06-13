namespace PNI.EShop.Core._Common
{
    public interface IIdentity<out TId>
    {
        TId Id { get; }
    }
}
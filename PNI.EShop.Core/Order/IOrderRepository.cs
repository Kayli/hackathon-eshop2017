using PNI.EShop.Core.Order.DataAccess;

namespace PNI.EShop.Core.Order
{
    public interface IOrderRepository
    {
        void SaveProduct(Product product);
        void SaveOrder(DataAccess.Order order);
    }
}
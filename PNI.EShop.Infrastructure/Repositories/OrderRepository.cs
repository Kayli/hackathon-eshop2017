using PNI.EShop.Core.Order;
using System.Data.Entity;
using FakeDbSet;
using PNI.EShop.Core.Order.DataAccess;

namespace PNI.EShop.Infrastructure
{

    public class OrderRepository : IOrderRepository
    {
        public IDbSet<Order> Orders { get; set; }
        public IDbSet<Product> Products { get; set; }

        public OrderRepository()
        {
            this.Orders = new InMemoryDbSet<Order>();
            this.Products = new InMemoryDbSet<Product>();
        }

        public void SaveOrder(Order order)
        {
            DbSetHelper.IncrementPrimaryKey<Order>(x => x.Id, this.Orders);
            Orders.Add(order);
        }

        public void SaveProduct(Product product)
        {
            Products.Add(product);
        }
    }

}
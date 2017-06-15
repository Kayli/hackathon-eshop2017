using System;
using PNI.EShop.Core.Services;
using PNI.EShop.Core._Common;
using PNI.EShop.Core.Order.DataAccess;
using PNI.EShop.Core.Order.Events;

namespace PNI.EShop.Core.Order
{
    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepository;
        private IEventStore _eventStore;
        public OrderService(IOrderRepository orderRepository, IEventStore eventStore)
        {
            _orderRepository = orderRepository;
            _eventStore = eventStore;
        }
        public void Handle(ProductCreated @event)
        {
            Product product = new Product()
            {
                Id = @event.Id,
                Name = @event.Name
            };
            _orderRepository.SaveProduct(product);
        }

        public void Handle(Events.OrderCreated @event)
        {
            DataAccess.Order order = new DataAccess.Order()
            {
              //  OrderId = @event.OrderId,
                ProductId = @event.ProductId,
                CustomerFirstName = @event.Customer.FirstName
            };
            _orderRepository.SaveOrder(order);
        }

        public void CreateOrder(Guid productId, Customer customer)
        {

            _eventStore.Publish(new OrderCreated
            {
               // OrderId = orderId,
                ProductId = productId,
                Customer = customer
            });
        }
    }
}
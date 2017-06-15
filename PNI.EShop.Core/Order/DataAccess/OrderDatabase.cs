using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace PNI.EShop.Core.Order.DataAccess
{
   
    public class Order
    {
        [Key]
        public long Id { get; set; }
        public Guid ProductId { get; set; }
        public string CustomerFirstName { get; set; }
    }

    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public interface IFactory<T>
    {
        T Create();
    }
}

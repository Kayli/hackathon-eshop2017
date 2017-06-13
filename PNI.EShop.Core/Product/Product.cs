using System;
using PNI.EShop.Core._Common;

namespace PNI.EShop.Core.Product
{
    public class Product : Entity<Guid>
    {
        public Product(ProductId id, StringValue name, StringValue description, ProductModel model, DateValue createdAt, DateValue modifiedAt) : base(id)
        {
            Name = name;
            Description = description;
            Model = model;
            CreatedAt = createdAt;
            ModifiedAt = modifiedAt;
        }
        
        public StringValue Name { get; }
        public StringValue Description { get; }
        public ProductModel Model { get; }
        public DateValue CreatedAt { get; }
        public DateValue ModifiedAt { get; }
    }
}
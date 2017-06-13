using System;
using PNI.DDD.Core;

namespace PNI.EShop.Domain
{
    public class Product : Entity<Guid>
    {
        public Product(IIdentity<Guid> id) : base(id)
        {
        }

        public StringValue Name { get; }
        public StringValue Description { get; }
        public DateValue CreatedAt { get; }
        public DateValue ModifiedAt { get; }
    }
}
using System;
using PNI.EShop.Core._Common;

namespace PNI.EShop.Core.Product
{
    public class ProductId : Identity<Guid>
    {
        public ProductId(Guid id) : base(id)
        {
        }
    }
}
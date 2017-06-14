using System;

namespace PNI.EShop.Core.ProductCatalog.Data
{
    public class ProductId : Identity<Guid>
    {
        public ProductId(Guid id) : base(id)
        {
        }
    }
}
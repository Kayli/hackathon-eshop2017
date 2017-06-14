using System;
using System.Runtime.Serialization;

namespace PNI.EShop.Core.ProductCatalog.DataAccess
{
    [DataContract]
    public class ProductDto
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public ProductModelDto Model { get; set; }
        [DataMember]
        public DateTimeOffset CreatedAt { get; set; }
        [DataMember]
        public DateTimeOffset ModifiedAt { get; set; }
    }
}
using System;
using System.Runtime.Serialization;

namespace PNI.EShop.Core.ProductCatalog.DataAccess
{
    [DataContract]
    public class ProductModelDto
    {
        [DataMember]
        public ColorDefinition Color { get; set; }
        [DataMember]
        public ModelTypeDefinition Type { get; set; }
        [DataMember]
        public DateTimeOffset CreatedAt { get; set; }
        [DataMember]
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
using System;
using PNI.EShop.Core._Common;
using PNI.EShop.Core.Product;

namespace PNI.EShop.Core.Services
{
    public class ProductCreated : EventBase
    {
        public Guid      Id { get; set; }
        public string    Name { get; set; }
        public string    Description { get; set; }
        public ModelType Type { get; set; }
        public ColorDefinition Color { get; set; }
    }
}
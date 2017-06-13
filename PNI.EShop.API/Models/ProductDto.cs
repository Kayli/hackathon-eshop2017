using System;
using PNI.EShop.Core._Common;

namespace PNI.EShop.API.Models
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public ColorDefinition Color { get; set; }
        public ModelTypeDefinition Type { get; set; }
        public string Name { get; set; }

        public string FileRelativePath { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}
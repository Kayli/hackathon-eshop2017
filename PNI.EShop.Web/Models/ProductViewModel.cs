using System;
using PNI.EShop.Core;

namespace PNI.EShop.Web.Models
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public ColorDefinition Color { get; set; }
        public ModelTypeDefinition Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}
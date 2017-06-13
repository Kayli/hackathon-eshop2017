using PNI.EShop.Core;

namespace PNI.EShop.UI.Models
{
    public class ProductViewModel
    {
        public ColorDefinition Color { get; set; }
        public ModelTypeDefinition Type { get; set; }
        public string Name { get; set; }
        public string FileRelativePath { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
    }
}
using PNI.EShop.Core;

namespace PNI.EShop.UI.Models
{
    public class ProductViewModel
    {
        private  ColorDefinition Color { get; set; }
        private  ModelTypeDefinition Type { get; set; }
        private  string Name { get; set; }
        private  string FileRelativePath { get; set; }
        private  string CreatedAt { get; set; }
        private  string UpdatedAt { get; set; }
    }
}
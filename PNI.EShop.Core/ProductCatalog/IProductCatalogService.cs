using PNI.EShop.Core.Product;
using PNI.EShop.Core._Common;

namespace PNI.EShop.Core.Services
{
    public interface IProductCatalogService
    {
        void CreateProduct(string name, string description, ModelType type, ColorDefinition color);
    }
}
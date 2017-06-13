using System;
using System.Threading.Tasks;
using PNI.EShop.Web.Models;

namespace PNI.EShop.Web.Services
{
    public interface IProductsService
    {
        Task<ProductViewModel[]> ListOfAllProductsAsync();
        Task<ProductViewModel> ProductByIdAsync(Guid id);
    }
}
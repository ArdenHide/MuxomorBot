using MuxomorBot.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MuxomorBot.Services
{
    public interface IProductService
    {
        Task<List<Category>> GetCategoriesAsync();
        string GetProductType(string displayName);

        Task<List<Product>> GetProductsAsync(string productType);
    }
}

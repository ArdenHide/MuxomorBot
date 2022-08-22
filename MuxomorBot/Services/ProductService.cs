using Microsoft.EntityFrameworkCore;
using MuxomorBot.Data;
using MuxomorBot.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MuxomorBot.Services
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetCategoriesAsync() =>
            await _context.Categories.ToListAsync();
        public string GetProductType(string displayName) =>
            _context.Categories.FirstOrDefault(x => x.DisplayName == displayName).Name;

        public async Task<List<Product>> GetProductsAsync(string productType) =>
            await _context.Products.Where(x => x.Type == productType).ToListAsync();
    }
}

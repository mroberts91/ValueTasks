using Microsoft.Extensions.Caching.Memory;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ValueTasks
{
    public class ProductService
    {
        private readonly DataContext _context;
        private readonly IMemoryCache _cache;
        private const string _cacheKey = "PRODUCTS";
        public ProductService()
        {
            _context = new();
            _cache = new MemoryCache(new MemoryCacheOptions());
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            if (_cache.TryGetValue<IEnumerable<Product>>(_cacheKey, out var products))
                return products;

            products = await _context.Set<Product>().ToListAsync();
            _cache.Set(_cacheKey, products, TimeSpan.FromMinutes(20));

            return products;
        }

        public async ValueTask<IEnumerable<Product>> GetProductsValueTaskAsync()
        {
            if (_cache.TryGetValue<IEnumerable<Product>>(_cacheKey, out var products))
                return products;

            products = await _context.Set<Product>().ToListAsync();
            _cache.Set(_cacheKey, products, TimeSpan.FromMinutes(20));

            return products;
        }
    }
}

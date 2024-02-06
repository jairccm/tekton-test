using Microsoft.Extensions.Caching.Memory;
using Prueba.Tekton.Application.Contratcs.Cache;

namespace Prueba.Tekton.Infraestructure.Cache
{
    public class ProductStatusCache : IProductStatusCache
    {
        private readonly IMemoryCache _cache;

        public ProductStatusCache(IMemoryCache cache)
        {
            _cache = cache;
        }

        public Dictionary<int, string> GetDictotionaryProductStatus()
        {
            return _cache.GetOrCreate("DictotionaryProductStatus", entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
                return GetProductStatus();
            });
        }

        private Dictionary<int, string> GetProductStatus()
        {
            return new Dictionary<int, string>
        {
            { 1, "Active" },
            { 0, "Inactive" }
        };
        }
    }
}

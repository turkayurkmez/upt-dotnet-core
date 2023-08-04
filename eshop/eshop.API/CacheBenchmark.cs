using eshop.Application.DataTransferObject.Responses;

namespace eshop.API
{
    public class CacheBenchmark
    {
        public IEnumerable<ProductListDisplayResponse> Products { get; set; }
        public DateTime CachedTime { get; set; }
    }
}

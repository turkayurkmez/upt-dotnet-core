using eshop.API.Filters;
using eshop.Application.DataTransferObject.Requests;
using eshop.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace eshop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductService _productService;
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger _logger;

        public ProductsController(ILogger<ProductsController> logger, IProductService productService, IMemoryCache memoryCache)
        {
            _productService = productService;
            _memoryCache = memoryCache;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProducts()
        {
            //REpresentational State Transfer
            //eğer bellekte "allProducts" isimli bir veri yoksa:
            if (!_memoryCache.TryGetValue("allProducts", out CacheBenchmark cacheBenchmark))
            {
                //o zaman db'ye git veriyi çek ve cache'e at:
                cacheBenchmark = new CacheBenchmark()
                {
                    CachedTime = DateTime.Now,
                    Products = await _productService.GetProductsAsync()


                };

                var options = new MemoryCacheEntryOptions()
                                  .SetAbsoluteExpiration(TimeSpan.FromMinutes(1))
                                  .SetPriority(CacheItemPriority.Normal)
                                  .RegisterPostEvictionCallback((key, value, evictionReason, state) =>
                                  {
                                      //cache'de tutulan veri, cache'den düştüğü zaman bu callback metodu çalışacak.
                                      _logger.LogInformation($"{key.ToString()} verisi cache'den çıkarıldı... Sebep: {evictionReason.ToString()}");

                                  });


                _memoryCache.Set("allProducts", cacheBenchmark, options);
            }
            _logger.LogInformation($"{cacheBenchmark.CachedTime} anında get request çalıştı. Ve veri cache'lendi");
            return Ok(cacheBenchmark);


            //var products = await _productService.GetProductsAsync();
            //return Ok(products);
        }
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ResponseCache(Duration = 70, VaryByQueryKeys = new[] { "id" }, Location = ResponseCacheLocation.Client)]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetProductAsync(id);
            if (product != null)
            {
                return Ok(new { product = product, date = DateTime.Now });

            }
            return NotFound();
        }
        [HttpGet("[action]/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Search(string name)
        {
            var products = await _productService.GetProductsByNameAsync(name);
            return Ok(products);

        }
        [Authorize(Roles = "admin,editor")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create(CreateProductRequest request)
        {
            if (ModelState.IsValid)
            {
                var createdProductId = await _productService.CreateNewProductAstnc(request);
                return CreatedAtAction(nameof(GetById), routeValues: new { id = createdProductId }, null);

            }
            return BadRequest(ModelState);

        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [IsExists]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProductRequest request)
        {

            //if (await _productService.IsProductExists(id))
            //{

            if (request.Id == id && ModelState.IsValid)
            {
                await _productService.UpdateProductAsync(request);
                return Ok(request);
            }
            return BadRequest(ModelState);
            //}
            //return NotFound();


        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [IsExists]
        public async Task<IActionResult> Delete(int id)
        {
            //if (await _productService.IsProductExists(id))
            {
                await _productService.DeleteProduct(id);
                return Ok();

                //}
                //return NotFound();
            }
        }
        //[HttpPut()]
        //[RangeException]
        //public IActionResult ChangeProductPrice(int id, decimal price)
        //{
        //    if (price <= 0)
        //    {
        //        throw new ArgumentOutOfRangeException("price");
        //    }
        //    return Ok();
        //}





    }
}

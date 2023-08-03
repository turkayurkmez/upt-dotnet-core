using eshop.Application.DataTransferObject.Requests;
using eshop.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace eshop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProducts()
        {
            //REpresentational State Transfer
            var products = await _productService.GetProductsAsync();
            return Ok(products);
        }
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetProductAsync(id);
            if (product != null)
            {
                return Ok(product);

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
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProductRequest request)
        {

            if (await _productService.IsProductExists(id))
            {

                if (request.Id == id && ModelState.IsValid)
                {
                    await _productService.UpdateProductAsync(request);
                    return Ok(request);
                }
                return BadRequest(ModelState);
            }
            return NotFound();


        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            if (await _productService.IsProductExists(id))
            {
                //await _productService.
                return Ok();

            }
            return NotFound();
        }



    }
}

using eshop.Application.DataTransferObject.Requests;
using eshop.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eshop.MVC.Controllers
{
    [Authorize(Roles = "admin,editor")]
    public class ProductsController : Controller
    {

        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public ProductsController(IProductService productService, ICategoryService categoryService)
        {

            this.productService = productService;
            this.categoryService = categoryService;
        }


        public IActionResult Index()
        {
            var products = productService.GetProducts();

            return View(products);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await getCategories();

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductRequest request)
        {
            if (ModelState.IsValid)
            {
                var lastProductId = await productService.CreateNewProductAstnc(request);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = await getCategories();
            return View();


        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await productService.GetProductAsync(id);
            var request = new UpdateProductRequest
            {
                CategoryId = product.CategoryId,
                Description = product.Description,
                Discount = product.Discount,
                Id = product.Id,
                ImageUrl = product.ImageUrl,
                Name = product.Name,
                Price = product.Price,
                StockCount = product.StockCount
            };
            ViewBag.Categories = await getCategories();
            return View(request);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateProductRequest request)
        {
            if (ModelState.IsValid)
            {
                await productService.UpdateProductAsync(request);
                return RedirectToAction(nameof(Index));

            }
            ViewBag.Categories = await getCategories();
            return View();

        }

        private async Task<IEnumerable<SelectListItem>> getCategories()
        {
            var categories = await categoryService.GetCategoryMenusAsync();
            return categories.Select(c => new SelectListItem { Text = c.Name, Value = c.Id.ToString() });

        }


    }
}

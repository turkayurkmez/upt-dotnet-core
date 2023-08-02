using eshop.Application.DataTransferObject.Requests;
using eshop.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace eshop.MVC.Controllers
{
    public class ProductsController : Controller
    {

        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult Index()
        {
            var products = productService.GetProducts();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateProductRequest request)
        {
            productService.CreateNewProductAstnc(request);
            return RedirectToAction(nameof(Index));
        }
    }
}

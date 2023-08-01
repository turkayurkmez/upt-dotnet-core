using eshop.Application.Services;
using eshop.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace eshop.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService productService;

        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            this.productService = productService;
        }

        public IActionResult Index(int pageNo = 1)
        {
            var products = productService.GetProducts();
            var total = products.Count();
            var pageSize = 4;
            var totalPage = Math.Ceiling((decimal)total / pageSize);

            var paginatedProducts = products.OrderBy(p => p.Id)
                                            .Skip((pageNo - 1) * pageSize)
                                            .Take(pageSize);

            ViewBag.TotalPage = totalPage;
            return View(paginatedProducts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
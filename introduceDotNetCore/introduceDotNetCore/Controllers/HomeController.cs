using introduceDotNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace introduceDotNetCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllProducts()
        {
            var products = new List<Product>
            {
                new(){ Id =1, Name="X", Description="Desc X", Price= 10 },
                new(){ Id =1, Name="Y", Description="Desc Y", Price= 10 },
                new(){ Id =1, Name="Z", Description="Desc Z", Price= 10 },

            };
            return View(products);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                return Redirect("/");
            }

            return View();
        }
    }
}

using eshop.Application.Services;
using eshop.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace eshop.MVC.Controllers
{
    public class ShoppingController : Controller
    {

        private readonly IProductService productService;

        public ShoppingController(IProductService productService)
        {
            this.productService = productService;
        }

        public IActionResult Index()
        {
            ProductItemCollection productItemCollection = getCollectionFromSession();
            return View(productItemCollection);
        }



        public IActionResult Add(int id)
        {
            //1. id'si verilen ürünü servis ile bul.
            var product = productService.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }


            //2. Bu ürünü koleksiyona ekle.
            ProductItemCollection productItemCollection = getCollectionFromSession();
            ProductItem productItem = new ProductItem { Product = product, Quantity = 1 };
            productItemCollection.Add(productItem);
            //3. Koleksiyonu da session'a ekle
            saveCollectionToSession(productItemCollection);

            return View(productItem);
        }

        private void saveCollectionToSession(ProductItemCollection collection)
        {
            var serialized = JsonConvert.SerializeObject(collection);
            HttpContext.Session.SetString("sepet", serialized);
        }

        private ProductItemCollection getCollectionFromSession()
        {
            //eğer daha önce sepet oluşmuş ise Session içindeki objeyi döndür.
            //ilk kez oluşacaksa new ile oluştur ve döndür.
            var jsonResponse = HttpContext.Session.GetString("sepet");
            //Session["hede"] = "bilmem ne";
            if (!string.IsNullOrEmpty(jsonResponse))
            {
                var collection = JsonConvert.DeserializeObject<ProductItemCollection>(jsonResponse);
                return collection;
            }
            return new ProductItemCollection();
        }
    }
}

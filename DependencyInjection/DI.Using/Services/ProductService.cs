using DI.Using.Models;

namespace DI.Using.Services
{
    public class ProductService : IProductService
    {
        public IEnumerable<Product> GetProducts()
        {
            return new List<Product>()
            {
                new(){ Id=1, Name="Y", Description="Açıklama Y"},
                new(){ Id=2, Name="Z", Description="Açıklama Z"},
                new(){ Id=3, Name="A", Description="Açıklama A"},

            };
        }
    }
}

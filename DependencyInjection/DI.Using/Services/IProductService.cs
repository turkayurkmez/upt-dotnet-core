using DI.Using.Models;

namespace DI.Using.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts();
    }
}
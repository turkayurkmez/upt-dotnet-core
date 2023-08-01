using eshop.Entities;

namespace eshop.Infrastructure.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> SearchProductsByName(string name);
        Task<IEnumerable<Product>> SearchProductsByNameAsync(string name);
    }
}

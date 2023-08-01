using eshop.Application.DataTransferObject.Responses;

namespace eshop.Application.Services
{
    public interface IProductService
    {
        IEnumerable<ProductListDisplayResponse> GetProducts();
        Task<IEnumerable<ProductListDisplayResponse>> GetProductsAsync();
    }
}

using eshop.Application.DataTransferObject.Requests;
using eshop.Application.DataTransferObject.Responses;

namespace eshop.Application.Services
{
    public interface IProductService
    {
        IEnumerable<ProductListDisplayResponse> GetProducts();
        Task<IEnumerable<ProductListDisplayResponse>> GetProductsAsync();
        Task<IEnumerable<ProductListDisplayResponse>> GetProductsByNameAsync(string name);


        ProductListDisplayResponse GetProduct(int id);
        Task<ProductListDisplayResponse> GetProductAsync(int id);

        Task<int> CreateNewProductAstnc(CreateProductRequest request);
        Task<int> UpdateProductAsync(UpdateProductRequest request);




    }
}

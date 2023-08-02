using AutoMapper;
using eshop.Application.DataTransferObject.Requests;
using eshop.Application.DataTransferObject.Responses;
using eshop.Entities;
using eshop.Infrastructure.Repositories;

namespace eshop.Application.Services
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public async Task<int> CreateNewProductAstnc(CreateProductRequest request)
        {
            var product = mapper.Map<Product>(request);
            await productRepository.CreateNewAsync(product);
            return product.Id;
        }

        public ProductListDisplayResponse GetProduct(int id)
        {
            return mapper.Map<ProductListDisplayResponse>(productRepository.Get(id));
        }

        public async Task<ProductListDisplayResponse> GetProductAsync(int id)
        {
            return mapper.Map<ProductListDisplayResponse>(await productRepository.GetAsync(id));
        }

        public IEnumerable<ProductListDisplayResponse> GetProducts()
        {
            var products = productRepository.GetAll();
            //return products.Select(p => new ProductListDisplayResponse
            //{
            //    Description = p.Description,
            //    Discount = p.Discount,
            //    Id = p.Id,
            //    ImageUrl = p.ImageUrl,
            //    Name = p.Name,
            //    Price = p.Price
            //});

            return mapper.Map<IEnumerable<ProductListDisplayResponse>>(products);
        }

        public async Task<IEnumerable<ProductListDisplayResponse>> GetProductsAsync()
        {
            return mapper.Map<IEnumerable<ProductListDisplayResponse>>(await productRepository.GetAllAsync());
        }

        public async Task<IEnumerable<ProductListDisplayResponse>> GetProductsByNameAsync(string name)
        {
            return mapper.Map<IEnumerable<ProductListDisplayResponse>>(await productRepository.SearchProductsByNameAsync(name));

        }

        public async Task<int> UpdateProductAsync(UpdateProductRequest request)
        {
            var product = mapper.Map<Product>(request);
            await productRepository.UpdateAsync(product);
            return product.Id;
        }
    }
}

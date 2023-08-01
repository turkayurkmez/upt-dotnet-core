using AutoMapper;
using eshop.Application.DataTransferObject.Responses;
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

        public Task<IEnumerable<ProductListDisplayResponse>> GetProductsAsync()
        {
            throw new NotImplementedException();
        }
    }
}

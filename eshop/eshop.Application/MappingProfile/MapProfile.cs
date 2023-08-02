using AutoMapper;
using eshop.Application.DataTransferObject.Requests;
using eshop.Application.DataTransferObject.Responses;
using eshop.Entities;

namespace eshop.Application.MappingProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductListDisplayResponse>();
            CreateMap<Category, CategoryMenuResponse>();
            CreateMap<CreateProductRequest, Product>();
            CreateMap<UpdateProductRequest, Product>();
        }
    }
}

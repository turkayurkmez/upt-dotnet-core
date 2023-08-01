using AutoMapper;
using eshop.Application.DataTransferObject.Responses;
using eshop.Infrastructure.Repositories;

namespace eshop.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IMapper mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            this.categoryRepository = categoryRepository;
            this.mapper = mapper;
        }

        public IEnumerable<CategoryMenuResponse> GetCategoryMenus()
        {
            var categories = categoryRepository.GetAll();
            return mapper.Map<IEnumerable<CategoryMenuResponse>>(categories);
        }
    }
}

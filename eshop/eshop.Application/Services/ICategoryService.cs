using eshop.Application.DataTransferObject.Responses;

namespace eshop.Application.Services
{
    public interface ICategoryService
    {
        IEnumerable<CategoryMenuResponse> GetCategoryMenus();
    }
}

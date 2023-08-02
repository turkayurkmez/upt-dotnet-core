using eshop.Application.DataTransferObject.Responses;

namespace eshop.MVC.Models
{
    public class IndexViewModel
    {
        public IEnumerable<ProductListDisplayResponse> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}

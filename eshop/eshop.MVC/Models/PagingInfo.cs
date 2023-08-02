namespace eshop.MVC.Models
{
    public class PagingInfo
    {
        public int TotalItemsCount { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get => (int)Math.Ceiling((decimal)TotalItemsCount / PageSize); }
    }
}

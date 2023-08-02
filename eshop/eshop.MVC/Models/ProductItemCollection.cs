using eshop.Application.DataTransferObject.Responses;

namespace eshop.MVC.Models
{
    public class ProductItem
    {
        public ProductListDisplayResponse Product { get; set; }
        public int Quantity { get; set; } = 1;
    }
    public class ProductItemCollection
    {
        public List<ProductItem> ProductItems { get; set; } = new List<ProductItem>();

        public void Add(ProductItem productItem)
        {
            var existingProduct = ProductItems.FirstOrDefault(p => p.Product.Id == productItem.Product.Id);
            if (existingProduct != null)
            {
                existingProduct.Quantity += productItem.Quantity;
            }
            else
            {
                ProductItems.Add(productItem);
            }

        }

        public decimal? TotalPrice() => ProductItems.Sum(p => (p.Product.Price * (1 - p.Product.Discount)) * p.Quantity);

        public void Clear() => ProductItems.Clear();

    }
}

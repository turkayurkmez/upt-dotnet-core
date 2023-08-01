using DI.Using.Models;

namespace DI.Using.Services
{
    //Gelecekte....
    public class AnotherProductService : IProductService
    {
        public IEnumerable<Product> GetProducts()
        {
            return new List<Product>()
            {
                new(){ Id=1, Name="Q1", Description="Açıklama Q1"},
                new(){ Id=2, Name="Q2", Description="Açıklama Q2"},
                new(){ Id=3, Name="Q3", Description="Açıklama Q3"},

            };
        }
    }
}

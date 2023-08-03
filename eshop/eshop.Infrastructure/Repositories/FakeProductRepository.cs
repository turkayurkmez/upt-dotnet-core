//using eshop.Entities;

//namespace eshop.Infrastructure.Repositories
//{
//    public class FakeProductRepository : IProductRepository
//    {
//        private List<Product> products;
//        public FakeProductRepository()
//        {
//            products = new List<Product> {
//                new (){ Id = 1, Name="Fake A", Price=10, Discount=0.15m, Description="Fake A Description" },
//                new (){ Id = 2, Name="Fake B", Price=10, Discount=0.15m, Description="Fake B Description" },
//                new (){ Id = 3, Name="Fake C", Price=10, Discount=0.15m, Description="Fake C Description" },
//                new (){ Id = 4, Name="Fake D", Price=10, Discount=0.15m, Description="Fake D Description" },
//                new (){ Id = 5, Name="Fake E", Price=10, Discount=0.15m, Description="Fake E Description" },
//                new (){ Id = 6, Name="Fake F", Price=10, Discount=0.15m, Description="Fake F Description" },

//            };
//        }
//        public void CreateNew(Product entity)
//        {
//            products.Add(entity);
//        }

//        public Task CreateNewAsync(Product entity)
//        {
//            throw new NotImplementedException();
//        }

//        public void Delete(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public Task DeleteAsync(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public Product Get(int id)
//        {
//            return products.Find(p => p.Id == id);
//        }

//        public IEnumerable<Product> GetAll()
//        {
//            return products;
//        }

//        public Task<IEnumerable<Product>> GetAllAsync()
//        {
//            throw new NotImplementedException();
//        }

//        public Task<Product> GetAsync(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public IEnumerable<Product> SearchProductsByName(string name)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<IEnumerable<Product>> SearchProductsByNameAsync(string name)
//        {
//            throw new NotImplementedException();
//        }

//        public void Update(Product entity)
//        {
//            throw new NotImplementedException();
//        }

//        public Task UpdateAsync(Product entity)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}

using eshop.Entities;
using eshop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace eshop.Infrastructure.Repositories
{
    public class EFProductRepository : IProductRepository
    {
        private readonly EshopDbContext dbContext;

        public EFProductRepository(EshopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void CreateNew(Product entity)
        {
            throw new NotImplementedException();
        }

        public async Task CreateNewAsync(Product entity)
        {
            await dbContext.Products.AddAsync(entity);
            await dbContext.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();

        }

        public async Task DeleteAsync(int id)
        {
            var product = await dbContext.Products.SingleOrDefaultAsync(p => p.Id == id);
            dbContext.Products.Remove(product);
            await dbContext.SaveChangesAsync();
        }

        public Product Get(int id)
        {
            return dbContext.Products.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return dbContext.Products.ToList();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await dbContext.Products.ToListAsync();
        }

        public async Task<Product> GetAsync(int id)
        {
            return await dbContext.Products.FindAsync(id);
        }

        public async Task<bool> IsExistsAsync(int id)
        {
            return await dbContext.Products.AnyAsync(p => p.Id == id);
        }

        public IEnumerable<Product> SearchProductsByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Product>> SearchProductsByNameAsync(string name)
        {
            return await dbContext.Products.Where(p => p.Name.Contains(name)).ToListAsync();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Product entity)
        {
            dbContext.Products.Update(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}

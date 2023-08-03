using eshop.Entities;
using eshop.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace eshop.Infrastructure.Repositories
{
    public class EFCategoryRepository : ICategoryRepository
    {
        private readonly EshopDbContext eshopDbContext;

        public EFCategoryRepository(EshopDbContext eshopDbContext)
        {
            this.eshopDbContext = eshopDbContext;
        }

        public void CreateNew(Category entity)
        {
            throw new NotImplementedException();
        }

        public async Task CreateNewAsync(Category entity)
        {
            await eshopDbContext.Categories.AddAsync(entity);
            await eshopDbContext.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            var category = await eshopDbContext.Categories.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
            eshopDbContext.Categories.Remove(category);
            await eshopDbContext.SaveChangesAsync();
        }

        public Category Get(int id)
        {
            return eshopDbContext.Categories.FirstOrDefault(c => c.Id == id);
            ;
        }

        public IEnumerable<Category> GetAll()
        {
            return eshopDbContext.Categories.ToList();
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await eshopDbContext.Categories.ToListAsync();
        }

        public async Task<Category> GetAsync(int id)
        {
            return await eshopDbContext.Categories.SingleOrDefaultAsync(c => c.Id == id);
        }

        public Task<bool> IsExistsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Category entity)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Category entity)
        {
            eshopDbContext.Categories.Update(entity);
            await eshopDbContext.SaveChangesAsync();

        }
    }
}

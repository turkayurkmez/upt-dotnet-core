using eshop.Entities;

namespace eshop.Infrastructure.Repositories
{
    public interface IRepository<T> where T : IEntity
    {
        T Get(int id);
        Task<T> GetAsync(int id);
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();

        void CreateNew(T entity);
        Task CreateNewAsync(T entity);

        Task DeleteAsync(int id);
        void Delete(int id);

        void Update(T entity);
        Task UpdateAsync(T entity);

        Task<bool> IsExistsAsync(int id);

    }
}

using Domain.Model;

namespace Domain.Interface
{
    public interface IGenericRepository<T> where T : Entity
    {
        IQueryable<T> Entities { get; }

        Task<T?> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task SaveAsync();
    }
}

using Domain.Model;

namespace Domain.Interface
{
    public interface IGenericRepository<T> where T : Entity
    {
        Task<List<T>> GetAllAsync();
        Task AddRangeAsync(IEnumerable<T> entities);
        Task SaveAsync();
    }
}

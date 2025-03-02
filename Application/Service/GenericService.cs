using Domain.Interface;
using Domain.Model;

namespace Application.Service
{
    public class GenericService<T>(IGenericRepository<T> repository) where T : Entity
    {
        protected readonly IGenericRepository<T> Repository = repository;
        public async Task<IEnumerable<T>> GetAllAsync() => await Repository.GetAllAsync();
        public async Task<T?> GetByIdAsync(int id) => await Repository.GetByIdAsync(id);
        public async Task<T> AddAsync(T entity) => await Repository.AddAsync(entity);
        public async Task AddRangeAsync(IEnumerable<T> entities) => await Repository.AddRangeAsync(entities);
        public async Task UpdateAsync(T entity) => await Repository.UpdateAsync(entity);
        public async Task DeleteAsync(T entity) => await Repository.DeleteAsync(entity);
        public async Task SaveAsync() => await Repository.SaveAsync();

    }
}

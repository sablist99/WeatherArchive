using Domain.Interface;
using Domain.Model;

namespace Application.Service
{
    public class GenericService<T>(IGenericRepository<T> repository) where T : Entity
    {
        protected readonly IGenericRepository<T> Repository = repository;
        public async Task<IEnumerable<T>> GetAllAsync() => await Repository.GetAllAsync();
        public async Task AddRangeAsync(IEnumerable<T> entities) => await Repository.AddRangeAsync(entities);

    }
}

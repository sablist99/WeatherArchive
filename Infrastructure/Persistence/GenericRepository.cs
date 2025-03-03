using Domain.Interface;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repository
{
    public class GenericRepository<T>(ApplicationContext dbContext) : IGenericRepository<T> where T : Entity
    {
        protected readonly ApplicationContext DbContext = dbContext;

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            try
            {
                await DbContext.Set<T>().AddRangeAsync(entities);
                await SaveAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.InnerException?.Message ?? "Ошибка обновления базы данных.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при добавлении записи: {ex.Message}");
            }
        }

        public async Task<List<T>> GetAllAsync()
        {
            try
            {
                return await DbContext.Set<T>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при получении записей: {ex.Message}");
            }
        }

        public async Task SaveAsync()
        {
            await DbContext.SaveChangesAsync();
        }
    }
}

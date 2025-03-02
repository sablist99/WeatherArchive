using Domain.Interface;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repository
{
    public class GenericRepository<T>(ApplicationContext dbContext) : IGenericRepository<T> where T : Entity
    {
        protected readonly ApplicationContext DbContext = dbContext;

        public IQueryable<T> Entities => DbContext.Set<T>();

        public async Task<T> AddAsync(T entity)
        {
            try
            {
                await DbContext.Set<T>().AddAsync(entity);
                await SaveAsync();
                return entity;
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

        public async Task UpdateAsync(T entity)
        {
            try
            {
                T? exist = await DbContext.Set<T>().FindAsync(entity.Id) ?? throw new Exception($"Запись с id {entity.Id} не найдена.");
                DbContext.Entry(exist).CurrentValues.SetValues(entity);
                await SaveAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.InnerException?.Message ?? "Ошибка обновления базы данных.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при обновлении записи: {ex.Message}");
            }
        }

        public async Task DeleteAsync(T entity)
        {
            try
            {
                DbContext.Set<T>().Remove(entity);
                await SaveAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception(ex.InnerException?.Message ?? "Ошибка обновления базы данных.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Ошибка при удалении записи: {ex.Message}");
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
        public async Task<T?> GetByIdAsync(int id)
        {
            return await DbContext.Set<T>().FindAsync(id) ?? throw new Exception($"Запись с id {id} не найдена.");
        }

        public async Task SaveAsync()
        {
            await DbContext.SaveChangesAsync();
        }
    }
}

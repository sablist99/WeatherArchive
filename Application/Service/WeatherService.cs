using Domain.Interface;
using Domain.Model;

namespace Application.Service
{
    public class WeatherService(IGenericRepository<Weather> repository) : GenericService<Weather>(repository)
    {
        public async Task<(List<Weather>, int TotalCount)> GetWeatherDataAsync(int? year = null, int? month = null, int pageNumber = 1, int pageSize = 100)
        {
            if (year.HasValue && (year < 1900 || year > DateTime.Now.Year))
            {
                throw new ArgumentOutOfRangeException(nameof(year), "Год должен быть в диапазоне от 1900 до текущего года.");
            }

            if (month.HasValue && (month < 1 || month > 12))
            {
                throw new ArgumentOutOfRangeException(nameof(month), "Месяц должен быть в диапазоне от 1 до 12.");
            }

            var data = await GetAllAsync();

            if (year.HasValue)
            {
                data = data.Where(w => w.Date.Year == year.Value);
            }

            if (month.HasValue)
            {
                data = data.Where(w => w.Date.Month == month.Value);
            }

            int totalCount = data.Count();

            var pagedData = data
                .OrderBy(w => w.Date)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return (pagedData, totalCount);
        }
    }
}

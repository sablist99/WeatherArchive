using Domain.Interface;
using Domain.Model;

namespace Application.Service
{
    public class WeatherService(IGenericRepository<Weather> repository) : GenericService<Weather>(repository)
    {
        public async Task<List<Weather>> GetWeatherDataAsync(int? year = null, int? month = null)
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

            return data.ToList();
        }
    }
}

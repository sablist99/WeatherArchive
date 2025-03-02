using Domain.Interface;
using Microsoft.AspNetCore.Http;

namespace Application.Service
{
    public class WeatherImportService(WeatherService weatherService, IWeatherImportParser parser)
    {
        private readonly WeatherService WeatherService = weatherService;
        private readonly IWeatherImportParser WeatherImportParser = parser;

        public async Task<bool> ProcessFilesAsync(List<IFormFile> files)
        {
            try
            {
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        using var stream = new MemoryStream();
                        await file.CopyToAsync(stream);
                        stream.Position = 0; // После копирования счетчик находится на последней позиции

                        var weatherData = WeatherImportParser.ParseFile(stream);

                        await WeatherService.AddRangeAsync(weatherData);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

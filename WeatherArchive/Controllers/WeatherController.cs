using Application.Service;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace WeatherArchive.Controllers
{
    public class WeatherController(WeatherService weatherService) : Controller
    {
        private readonly WeatherService WeatherService = weatherService;

        // GET: Weather/Index
        public async Task<IActionResult> Index(int? year = null, int? month = null, int pageNumber = 1, int pageSize = 100)
        {
            try
            {
                var (weatherData, totalCount) = await WeatherService.GetWeatherDataAsync(year, month, pageNumber, pageSize);

                ViewBag.PageNumber = pageNumber;
                ViewBag.PageSize = pageSize;
                ViewBag.TotalCount = totalCount;

                return View(weatherData); 
            }
            catch (ArgumentOutOfRangeException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(new List<Weather>());
            }
            catch (Exception ex)
            {
                // Логирование ошибки
                ViewBag.ErrorMessage = $"Произошла ошибка на сервере. {ex.Message}";
                return View(new List<Weather>());
            }
        }
    }
}

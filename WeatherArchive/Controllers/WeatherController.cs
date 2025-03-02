using Application.Service;
using Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace WeatherArchive.Controllers
{
    public class WeatherController(WeatherService weatherService) : Controller
    {
        private readonly WeatherService WeatherService = weatherService;

        // GET: Weather/Index
        public async Task<IActionResult> Index(int? year = null, int? month = null)
        {
            try
            {
                var weatherData = await WeatherService.GetWeatherDataAsync(year, month);
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

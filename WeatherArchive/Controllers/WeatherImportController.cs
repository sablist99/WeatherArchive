using Application.Service;
using Microsoft.AspNetCore.Mvc;

namespace WeatherArchive.Controllers
{
    public class WeatherImportController(WeatherImportService importService) : Controller
    {
        private readonly WeatherImportService WeatherImportService = importService;

        [HttpGet]
        public IActionResult UploadFiles()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadFiles(List<IFormFile> files)
        {
            if (files == null || files.Count == 0)
            {
                ViewBag.ErrorMessage = "Пожалуйста, выберите файлы для загрузки.";
                return View();
            }

            // Передаем файлы в сервис для обработки
            var result = await WeatherImportService.ProcessFilesAsync(files);

            if (result)
            {
                ViewBag.SuccessMessage = "Файлы успешно загружены и обработаны.";
            }
            else
            {
                ViewBag.ErrorMessage = "Произошла ошибка при обработке файлов.";
            }

            return View();
        }
    }
}

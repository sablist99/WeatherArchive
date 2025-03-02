using Domain.Interface;
using Domain.Model;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace Infrastructure.Import
{
    public class WeatherImportParserNpoi : IWeatherImportParser
    {
        public IEnumerable<Weather> ParseFile(Stream fileStream)
        {
            IWorkbook workbook;

            // Определяем формат файла (XLSX или XLS)
            if (fileStream.Length > 4 && fileStream.ReadByte() == 0x50 && fileStream.ReadByte() == 0x4B)
            {
                fileStream.Position = 0;
                workbook = new XSSFWorkbook(fileStream); // Для XLSX
            }
            else
            {
                fileStream.Position = 0;
                workbook = new HSSFWorkbook(fileStream); // Для XLS
            }

            var weatherData = new List<Weather>();

            // Обходим все листы, так как есть разбитие по месяцам
            for (int i = 0; i < workbook.NumberOfSheets; i++)
            {
                var sheet = workbook.GetSheetAt(i);

                // Данные начинаются с 5 строки (а отсчет строк с 0)
                for (int rowIndex = 4; rowIndex <= sheet.LastRowNum; rowIndex++)
                {
                    var row = sheet.GetRow(rowIndex);
                    if (row == null) continue;

                    // Чтение данных из ячеек
                    var date = DateTime.TryParse(row.GetCell(0)?.StringCellValue, out DateTime outDate) ? outDate : DateTime.MinValue; 

                    var time = TimeSpan.TryParse(row.GetCell(1)?.StringCellValue, out TimeSpan outTime) ? outTime : TimeSpan.Zero; 

                    var temperature = (decimal)(row.GetCell(2)?.NumericCellValue ?? 0); 

                    var humidity = (short)(row.GetCell(3)?.NumericCellValue ?? 0); 

                    var dewPoint = (decimal)(row.GetCell(4)?.NumericCellValue ?? 0); 

                    var pressure = (short)(row.GetCell(5)?.NumericCellValue ?? 0); 
                    
                    var windDirection = row.GetCell(6)?.StringCellValue;

                    var windSpeedCell = row.GetCell(7);
                    var windSpeed = windSpeedCell != null && windSpeedCell.CellType == CellType.Numeric
                        ? (short?)windSpeedCell.NumericCellValue
                        : null;

                    var cloudinessCell = row.GetCell(8);
                    var cloudiness = cloudinessCell != null && cloudinessCell.CellType == CellType.Numeric
                        ? (short?)cloudinessCell.NumericCellValue
                        : null;

                    var cloudBaseHeightCell = row.GetCell(9);
                    var cloudBaseHeight = cloudBaseHeightCell != null && cloudBaseHeightCell.CellType == CellType.Numeric
                        ? (int?)cloudBaseHeightCell.NumericCellValue
                        : null;

                    var horizontalVisibilityCell = row.GetCell(10);
                    var horizontalVisibility = horizontalVisibilityCell != null && horizontalVisibilityCell.CellType == CellType.Numeric
                        ? (decimal?)horizontalVisibilityCell.NumericCellValue
                        : null;

                    var weatherPhenomena = row.GetCell(11)?.StringCellValue; 

                    var weather = new Weather
                    {
                        Date = date,
                        Time = time,
                        Temperature = temperature,
                        Humidity = humidity,
                        DewPoint = dewPoint,
                        Pressure = pressure,
                        WindDirection = windDirection,
                        WindSpeed = windSpeed,
                        Cloudiness = cloudiness,
                        CloudBaseHeight = cloudBaseHeight,
                        HorizontalVisibility = horizontalVisibility,
                        WeatherPhenomena = weatherPhenomena
                    };

                    weatherData.Add(weather);
                }
            }

            return weatherData;
        }
    }
}

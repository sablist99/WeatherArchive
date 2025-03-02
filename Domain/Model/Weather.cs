namespace Domain.Model
{
    public class Weather
    {
        /// <summary>
        /// Уникальный идентификатор записи
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Дата наблюдения
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Время наблюдения
        /// </summary>
        public TimeSpan Time { get; set; }

        /// <summary>
        /// Температура воздуха (в градусах Цельсия)
        /// </summary>
        public decimal Temperature { get; set; }

        /// <summary>
        /// Относительная влажность (в процентах)
        /// </summary>
        public short Humidity { get; set; }

        /// <summary>
        /// Точка росы (в градусах Цельсия)
        /// </summary>
        public decimal DewPoint { get; set; }

        /// <summary>
        /// Атмосферное давление (в мм рт.ст.)
        /// </summary>
        public short Pressure { get; set; }

        /// <summary>
        /// Направление ветра (например, З,ЮЗ, штиль)
        /// </summary>
        public string? WindDirection { get; set; }

        /// <summary>
        /// Скорость ветра (в м/с)
        /// </summary>
        public decimal? WindSpeed { get; set; }

        /// <summary>
        /// Облачность (в %)
        /// </summary>
        public short? Cloudiness { get; set; }

        /// <summary>
        /// Нижняя граница облачности (в м)
        /// </summary>
        public int? CloudBaseHeight { get; set; }

        /// <summary>
        /// Горизонтальная видимость (в км)
        /// </summary>
        public decimal? HorizontalVisibility { get; set; }

        /// <summary>
        /// Погодные явления (например, Дымка)
        /// </summary>
        public string? WeatherPhenomena { get; set; }
    }
}

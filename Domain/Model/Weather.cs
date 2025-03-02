using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Model
{
    [Table("weather")]
    public class Weather : Entity
    {
        /// <summary>
        /// Дата наблюдения
        /// </summary>
        [Column("date", TypeName = "date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Время наблюдения
        /// </summary>
        [Column("time", TypeName = "time")]
        public TimeSpan Time { get; set; }

        /// <summary>
        /// Температура воздуха (в градусах Цельсия)
        /// </summary>
        [Column("temperature", TypeName = "decimal(4,1)")]
        public decimal Temperature { get; set; }

        /// <summary>
        /// Относительная влажность (в процентах)
        /// </summary>
        [Column("humidity", TypeName = "smallint")]
        public short Humidity { get; set; }

        /// <summary>
        /// Точка росы (в градусах Цельсия)
        /// </summary>
        [Column("dew_point", TypeName = "decimal(4,1)")]
        public decimal DewPoint { get; set; }

        /// <summary>
        /// Атмосферное давление (в мм рт.ст.)
        /// </summary>
        [Column("pressure", TypeName = "smallint")]
        public short Pressure { get; set; }

        /// <summary>
        /// Направление ветра (например, З,ЮЗ, штиль)
        /// </summary>
        [Column("wind_direction", TypeName = "varchar(10)")]
        public string? WindDirection { get; set; }

        /// <summary>
        /// Скорость ветра (в м/с)
        /// </summary>
        [Column("wind_speed", TypeName = "smallint")]
        public short? WindSpeed { get; set; }

        /// <summary>
        /// Облачность (в %)
        /// </summary>
        [Column("cloudiness", TypeName = "smallint")]
        public short? Cloudiness { get; set; }

        /// <summary>
        /// Нижняя граница облачности (в м)
        /// </summary>
        [Column("cloud_base_height", TypeName = "int")]
        public int? CloudBaseHeight { get; set; }

        /// <summary>
        /// Горизонтальная видимость (в км)
        /// </summary>
        [Column("horizontal_visibility", TypeName = "decimal(4,1)")]
        public decimal? HorizontalVisibility { get; set; }

        /// <summary>
        /// Погодные явления (например, Дымка)
        /// </summary>
        [Column("weather_phenomena", TypeName = "varchar(1000)")]
        public string? WeatherPhenomena { get; set; }
    }
}
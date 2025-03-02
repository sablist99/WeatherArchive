using Domain.Model;

namespace Domain.Interface
{
    public interface IWeatherImportParser
    {
        IEnumerable<Weather> ParseFile(Stream fileStream);
    }
}

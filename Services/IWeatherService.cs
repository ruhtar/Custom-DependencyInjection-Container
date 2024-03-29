
namespace DiContainer.Services
{
    public interface IWeatherService
    {
        IEnumerable<WeatherForecast> Get();
    }
}
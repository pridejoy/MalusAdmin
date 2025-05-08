namespace MalusAdmin.Servers;

public interface IWeatherForecastService
{
    Task<IEnumerable<WeatherForecast>> Get();

    Task CreatClass(string str);

    Task CreatTable();
}
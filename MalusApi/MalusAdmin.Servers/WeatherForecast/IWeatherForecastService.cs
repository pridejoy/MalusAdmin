namespace MalusAdmin.Servers.WeatherForecast;

public interface IWeatherForecastService
{
    Task<IEnumerable<WeatherForecast>> Get();

    Task CreatClass(string str);

    Task CreatTable();
}
using BlazorHtmxDemo.Features.Weather;
using Microsoft.AspNetCore.Http.HttpResults;

public static class WeatherEndpoints
{
    public static WebApplication MapWeatherEndpoints(this WebApplication app)
    {
        app.MapGet("/weather/forecasts", () => {
            return new RazorComponentResult<WeatherTable>();
        });

        return app;
    }
}
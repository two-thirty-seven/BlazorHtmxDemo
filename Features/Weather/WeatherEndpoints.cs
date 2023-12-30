using BlazorHtmxDemo.Features.Weather;
using Microsoft.AspNetCore.Http.HttpResults;

public static class WeatherEndpoints
{
    public static WebApplication MapWeatherEndpoints(this WebApplication app)
    {
        app.MapGet("/api/weather", () => new RazorComponentResult<WeatherTable>());

        return app;
    }
}
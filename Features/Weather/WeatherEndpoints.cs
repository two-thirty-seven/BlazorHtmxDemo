using BlazorHtmxDemo.Features.Weather;
using Microsoft.AspNetCore.Http.HttpResults;

public static class WeatherEndpoints
{
    public static WebApplication MapWeatherEndpoints(this WebApplication app)
    {
        app.MapGet("/weather/forecasts", () => {
            var startDate = DateOnly.FromDateTime(DateTime.Now);
            var summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };
            var forecasts = Enumerable.Range(1, 10).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = summaries[Random.Shared.Next(summaries.Length)]
            }).ToArray();
            return new RazorComponentResult<WeatherTable>(new { Forecasts = forecasts });
        });

        return app;
    }
}
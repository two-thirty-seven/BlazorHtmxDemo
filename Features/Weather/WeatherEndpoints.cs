using Microsoft.AspNetCore.Http.HttpResults;

namespace BlazorHtmxDemo.Features.Weather;

public class WeatherEndpoints : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/weather/forecasts", () => {
            var startDate = DateOnly.FromDateTime(DateTime.Now);
            string[] summaries = ["Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"];
            var forecasts = Enumerable.Range(1, 10).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = summaries[Random.Shared.Next(summaries.Length)]
            }).ToArray();
            return new RazorComponentResult<WeatherTable>(new { Forecasts = forecasts });
        });
    }
}
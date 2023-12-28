using BlazorHtmxDemo.Components.Partials;
using Microsoft.AspNetCore.Http.HttpResults;
using static BlazorHtmxDemo.Components.Partials.PageLinks;

public static class Endpoints
{
    public static WebApplication MapEndpoints(this WebApplication app)
    {
        app.MapGet("/api/love-htmx", () => new RazorComponentResult<LoveHtmx>());

        app.MapGet("/api/weather", () => new RazorComponentResult<WeatherTable>());
        
        app.MapGet("/api/links/{popupState}", (PopupMode popupState) => new RazorComponentResult<PageLinks>(new { PopupState = popupState }));

        return app;
    }
}
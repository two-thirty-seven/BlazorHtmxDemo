using BlazorHtmxDemo.Features.Menu;
using Microsoft.AspNetCore.Http.HttpResults;
using static BlazorHtmxDemo.Features.Menu.PageLinks;

public static class MenuEndpoints
{
    public static WebApplication MapMenuEndpoints(this WebApplication app)
    { 
        app.MapGet("/api/pagelinks", () => new RazorComponentResult<PageLinks>(new { MenuState = MenuViewMode.Open }));

        app.MapPut("/api/pagelinks", () => new RazorComponentResult<PageLinks>(new { MenuState = MenuViewMode.Closed }));

        return app;
    }
}
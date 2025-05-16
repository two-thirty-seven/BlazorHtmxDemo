using BlazorHtmxDemo.Features.Menu;
using Microsoft.AspNetCore.Http.HttpResults;

public static class MenuEndpoints
{
    public static WebApplication MapMenuEndpoints(this WebApplication app)
    { 
        app.MapGet("/api/pagelinks", () => new RazorComponentResult<PageLinks>());
        
        app.MapPut("/api/pagelinks", () => new RazorComponentResult<PageLinks>());

        return app;
    }
}
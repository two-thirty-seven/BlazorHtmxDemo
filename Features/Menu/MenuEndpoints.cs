using Microsoft.AspNetCore.Http.HttpResults;

namespace BlazorHtmxDemo.Features.Menu;

public static class MenuEndpoints
{
    public static WebApplication MapMenuEndpoints(this WebApplication app)
    { 
        app.MapGet("/api/pagelinks", () => new RazorComponentResult<PageLinks>());

        return app;
    }
}
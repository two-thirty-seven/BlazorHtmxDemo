using BlazorHtmxDemo.Features.Home;
using Microsoft.AspNetCore.Http.HttpResults;

public static class HomeEndpoints
{
    public static WebApplication MapHomeEndpoints(this WebApplication app)
    {
        app.MapGet("/api/love-htmx", () => new RazorComponentResult<LoveHtmx>());

        return app;
    }
}
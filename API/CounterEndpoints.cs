using BlazorHtmxDemo.Components.Partials;
using Microsoft.AspNetCore.Http.HttpResults;

public static class CounterEndpoints
{
    public static WebApplication MapCounterEndpoints(this WebApplication app)
    {
        app.MapGet("/api/counter", () => new RazorComponentResult<CurrentCount>());

        app.MapPost("/api/counter", (HttpContext context) =>
        {
            int currentCount = context.Session.GetInt32("CurrentCount").Value;
            currentCount++;
            context.Session.SetInt32("CurrentCount", currentCount);
            context.Response.Headers.Append("HX-Trigger", "counter-updated");

            return new RazorComponentResult<CurrentCount>();
        });

        return app;
    }
}
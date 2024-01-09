using BlazorHtmxDemo.Features.Counter;
using Microsoft.AspNetCore.Http.HttpResults;

public static class CounterEndpoints
{
    public static WebApplication MapCounterEndpoints(this WebApplication app)
    {
        app.MapGet("/api/counter", () => new RazorComponentResult<CurrentCount>());

        app.MapPost("/api/counter", (HttpContext context) =>
        {
            var state = context.Session.GetObjectFromJson<CounterState>();
            context.Session.SetObjectAsJson<CounterState>(state with { CurrentCount = state.CurrentCount + 1 });
            context.Response.Headers.Append("HX-Trigger", "counter-updated");
            return new RazorComponentResult<CurrentCount>();
        });

        return app;
    }
}
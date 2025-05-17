using Microsoft.AspNetCore.Http.HttpResults;

namespace BlazorHtmxDemo.Features.Counter;

public static class CounterEndpoints
{
    public static WebApplication MapCounterEndpoints(this WebApplication app)
    {
        app.MapGet("/api/counter", () => new RazorComponentResult<CurrentCount>());

        app.MapPatch("/api/counter/{increment}", (HttpContext context, int increment) =>
        {
            var state = context.Session.GetObjectFromJson<CounterState>();
            context.Session.SetObjectAsJson<CounterState>(state with { CurrentCount = state.CurrentCount + increment });
            context.Response.Headers.Append("HX-Trigger", "counter-updated");
            
            return new RazorComponentResult<CurrentCount>();
        });

        return app;
    }
}
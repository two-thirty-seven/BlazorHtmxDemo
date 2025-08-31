using Microsoft.AspNetCore.Http.HttpResults;

namespace BlazorHtmxDemo.Features.Counter;

public class CounterEndpoints : IHtmxEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/counter", () => new RazorComponentResult<CurrentCount>());

        app.MapPatch("/api/counter/{increment:int}", (HttpContext context, int increment) =>
        {
            var state = context.Session.GetObjectFromJson<CounterState>();
            context.Session.SetObjectAsJson<CounterState>(state with { CurrentCount = state.CurrentCount + increment });
            context.Response.Headers.Append("HX-Trigger", "counter-updated");
            
            return new RazorComponentResult<CurrentCount>();
        });
    }
}
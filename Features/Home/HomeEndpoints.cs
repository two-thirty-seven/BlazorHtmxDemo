using Microsoft.AspNetCore.Http.HttpResults;

namespace BlazorHtmxDemo.Features.Home;

public class HomeEndpoints : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/love-htmx", () => new RazorComponentResult<LoveHtmx>());
    }
}
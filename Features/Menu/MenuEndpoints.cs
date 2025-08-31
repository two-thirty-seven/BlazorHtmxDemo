using Microsoft.AspNetCore.Http.HttpResults;

namespace BlazorHtmxDemo.Features.Menu;

public class MenuEndpoints : IHtmxEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    { 
        app.MapGet("/api/pagelinks", () => new RazorComponentResult<PageLinks>());
    }
}
using BlazorHtmxDemo;
using BlazorHtmxDemo.Extensions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BlazorHtmxDemo.Features.Home;

public class HomeEndpoints : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/love-htmx", () => new RazorComponentResult<LoveHtmx>()).RequireHXRequest();

        app.MapGet("/session", (HttpContext context) => new RazorComponentResult<SessionValues>(new
        {
            context.Session
        })).RequireHXRequest();
    }
}
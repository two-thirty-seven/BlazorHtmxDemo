using BlazorHtmxDemo.Extensions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BlazorHtmxDemo.Features.Photos;

public class PhotosEndpoints : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
    app.MapGet("/photos/controls", () => new RazorComponentResult<PhotoControls>()).RequireHXRequest();

    app.MapGet("/photos/sheet", () => new RazorComponentResult<PhotoSheet>()).RequireHXRequest();

        app.MapPost("/photos/search", ([FromForm]int page, [FromForm]int size, HttpContext context) => {
            var state = context.Session.GetObjectFromJson<PhotosState>("Photos");
            context.Session.SetObjectAsJson<PhotosState>("Photos", state with { Page = page, Size = size });
            context.Response.Headers.Append("HX-Trigger", "photos-state-updated");
            return new RazorComponentResult<PhotoControls>();
        }).RequireHXRequest();

        app.MapPatch("/photos/{direction}", (HttpContext context, string direction) =>
        {
            var increment = direction switch
            {
                "next" => 1,
                "prev" => -1,
                _ => 0, // "next" or "previous" should be the only values we get here, but just in case...
            };
            
            var state = context.Session.GetObjectFromJson<PhotosState>("Photos");
            context.Session.SetObjectAsJson<PhotosState>("Photos", state with { Page = state.Page + increment });
            context.Response.Headers.Append("HX-Trigger", "photos-state-updated");
            return new RazorComponentResult<PhotoControls>();
        }).RequireHXRequest();
    }
}
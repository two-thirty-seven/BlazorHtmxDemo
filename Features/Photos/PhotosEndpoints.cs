using BlazorHtmxDemo.Features.Photos;
using Microsoft.AspNetCore.Http.HttpResults;

public static class PhotosEndpoints
{
    public static WebApplication MapPhotosEndpoints(this WebApplication app)
    {
        app.MapGet("/photos/controls", () => {
            return new RazorComponentResult<PhotoControls>();
        });

        app.MapGet("/photos/sheet", () => {
            return new RazorComponentResult<PhotoSheet>();
        });

        app.MapGet("/photos/search", (int page, int size, HttpContext context) => {
            var state = context.Session.GetObjectFromJson<PhotosState>();
            context.Session.SetObjectAsJson<PhotosState>(state with { Page = page, Size = size });
            context.Response.Headers.Append("HX-Trigger", "photos-state-updated");
            return new RazorComponentResult<PhotoControls>();
        });

        app.MapGet("/photos/prev", (HttpContext context) => {
            var state = context.Session.GetObjectFromJson<PhotosState>();
            context.Session.SetObjectAsJson<PhotosState>(state with { Page = state.Page - 1 });
            context.Response.Headers.Append("HX-Trigger", "photos-state-updated");
            return new RazorComponentResult<PhotoControls>();
        });

        app.MapGet("/photos/next", (HttpContext context) => {
            var state = context.Session.GetObjectFromJson<PhotosState>();
            context.Session.SetObjectAsJson<PhotosState>(state with { Page = state.Page + 1 });
            context.Response.Headers.Append("HX-Trigger", "photos-state-updated");
            return new RazorComponentResult<PhotoControls>();
        });

        return app;
    }
}
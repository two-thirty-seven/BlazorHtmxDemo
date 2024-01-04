using BlazorHtmxDemo.Features.Photos;
using Microsoft.AspNetCore.Http.HttpResults;

public static class PhotosEndpoints
{
    public static WebApplication MapPhotosEndpoints(this WebApplication app)
    {
        app.MapGet("/photos/search", (int page, int size) => {
            return new RazorComponentResult<PhotoSheet>(new { Page = page, Size = size });
        });

        return app;
    }
}
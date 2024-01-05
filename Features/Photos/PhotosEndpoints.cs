using BlazorHtmxDemo.Features.Photos;
using Microsoft.AspNetCore.Http.HttpResults;

public static class PhotosEndpoints
{
    public static WebApplication MapPhotosEndpoints(this WebApplication app)
    {
        app.MapGet("/photos/search", async (int page, int size, PhotosService photosService) => {
            var photos = await photosService.FetchPhotos(page, size);
            return new RazorComponentResult<PhotoSheet>(new { Photos = photos });
        });

        return app;
    }
}
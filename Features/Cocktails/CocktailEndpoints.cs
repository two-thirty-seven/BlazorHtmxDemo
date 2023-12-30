using BlazorHtmxDemo.Features.Cocktails;
using Microsoft.AspNetCore.Http.HttpResults;

public static class CocktailEndpoints
{
    public static WebApplication MapCocktailEndpoints(this WebApplication app)
    {
        app.MapGet("/cocktails/search", (string search, CocktailsService cocktailsService) => {
            return new RazorComponentResult<CocktailList>(new { Search = search });
        });

        app.MapGet("/cocktails/detail/{id}", (int id, CocktailsService cocktailsService) => {
            return new RazorComponentResult<CocktailDetail>(new { Id = id });
        });

        return app;
    }
}
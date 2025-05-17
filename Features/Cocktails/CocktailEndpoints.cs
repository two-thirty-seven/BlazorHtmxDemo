using Microsoft.AspNetCore.Http.HttpResults;

namespace BlazorHtmxDemo.Features.Cocktails;

public static class CocktailEndpoints
{
    public static WebApplication MapCocktailEndpoints(this WebApplication app)
    {
        app.MapGet("/cocktails/search", (string search) => new RazorComponentResult<CocktailList>(new { Search = search }));

        app.MapGet("/cocktails/detail/{id}", (int id, CocktailsService cocktailsService) => {
            var cocktail = cocktailsService.GetDrink(id);
            return new RazorComponentResult<CocktailDetail>(new { Cocktail = cocktail });
        });

        return app;
    }
}
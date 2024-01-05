using BlazorHtmxDemo.Features.Cocktails;
using Microsoft.AspNetCore.Http.HttpResults;

public static class CocktailEndpoints
{
    public static WebApplication MapCocktailEndpoints(this WebApplication app)
    {
        app.MapGet("/cocktails/search", async (string search, CocktailsService cocktailsService) => {
            var cocktails = await cocktailsService.SearchCocktails(search);
            return new RazorComponentResult<CocktailList>(new { Search = search, Cocktails = cocktails });
        });

        app.MapGet("/cocktails/detail/{id}", (int id, CocktailsService cocktailsService) => {
            var cocktail = cocktailsService.GetDrink(id);
            return new RazorComponentResult<CocktailDetail>(new { Cocktail = cocktail });
        });

        return app;
    }
}
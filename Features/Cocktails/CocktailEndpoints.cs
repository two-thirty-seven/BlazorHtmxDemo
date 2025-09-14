using Microsoft.AspNetCore.Http.HttpResults;

namespace BlazorHtmxDemo.Features.Cocktails;

public class CocktailEndpoints : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/cocktails/search", (string search) => new RazorComponentResult<CocktailList>(new { Search = search }));

        app.MapGet("/cocktails/detail/{id:int}", (int id, CocktailsService cocktailsService) => {
            var cocktail = cocktailsService.GetDrink(id);
            return new RazorComponentResult<CocktailDetail>(new { Cocktail = cocktail });
        });
    }
}
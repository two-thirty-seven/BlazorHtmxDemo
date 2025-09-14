using System.Text.Json.Nodes;
using Microsoft.Extensions.Caching.Memory;

namespace BlazorHtmxDemo.Features.Cocktails;

public class CocktailsService(
    IHttpClientFactory httpClientFactory,
    IConfiguration configuration,
    IMemoryCache memoryCache)
{
    public async Task<IEnumerable<Cocktail>> SearchCocktails(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return [];
        }

        var baseUrl = configuration.GetValue<string>($"Urls:Cocktails");
        var request = $"{baseUrl}/api/json/v1/1/search.php?s={name}";

        using var httpClient = httpClientFactory.CreateClient();
        var json = await httpClient.GetStringAsync(request);

        var document = JsonNode.Parse(json)!;
        var root = document.Root;
        if (root["drinks"] == null) return [];

        var drinksArray = root["drinks"]!.AsArray();
        if (drinksArray.Count == 0) return [];

        var drinks = drinksArray.Select(drink =>
            new Cocktail(
                drink!["idDrink"].GetInt32(),
                drink["strDrink"].GetString(),
                drink["strGlass"].GetString(),
                drink["strInstructions"].GetString(),
                drink["strDrinkThumb"].GetString(),
                GetIngredients(drink))
        ).ToArray();

        foreach(var drink in drinks)
        {
            memoryCache.Set(drink.Id, drink);
        }

        return drinks;
    }

    private static List<Ingredient> GetIngredients(JsonNode drink)
    {
        var ingredients = new List<Ingredient>();

        for (var i = 1; i < 16; i++)
        {
            if (drink[$"strIngredient{i}"] == null) break;

            var ingredientString = drink[$"strIngredient{i}"].GetString();
            var ingredientMeasure = drink[$"strMeasure{i}"].GetString();

            if (!string.IsNullOrEmpty(ingredientString))
            {
                ingredients.Add(new Ingredient(ingredientString, ingredientMeasure));
            }
        }

        return ingredients;
    }

    public Cocktail GetDrink(int id)
    {
        return memoryCache.Get<Cocktail>(id)!;
    }
}
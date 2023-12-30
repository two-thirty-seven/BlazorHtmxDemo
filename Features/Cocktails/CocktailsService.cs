using System.Text.Json.Nodes;
using BlazorHtmxDemo.Extensions;
using Microsoft.Extensions.Caching.Memory;

namespace BlazorHtmxDemo.Features.Cocktails;

public class CocktailsService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;
    private readonly IMemoryCache _memoryCache;


    public CocktailsService(IHttpClientFactory httpClientFactory, IConfiguration configuration, IMemoryCache memoryCache)
    {
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
        _memoryCache = memoryCache;
    }

    public async Task<IEnumerable<Cocktail>> SearchCocktails(string name)
    {
        var baseUrl = _configuration.GetValue<string>($"Urls:Cocktails");
        var request = $"{baseUrl}/api/json/v1/1/search.php?s={name}";

        HttpClient _httpClient = _httpClientFactory.CreateClient();
        var json = await _httpClient.GetStringAsync(request);

        var document = JsonNode.Parse(json)!;
        var root = document.Root;
        if (root["drinks"] == null) return Array.Empty<Cocktail>();

        var drinksArray = root["drinks"]!.AsArray();
        if (drinksArray.Count == 0) return Array.Empty<Cocktail>();

        var drinks = drinksArray.Select(drink =>
            new Cocktail(
                drink["idDrink"].GetInt32(),
                drink["strDrink"].GetString(),
                drink["strGlass"].GetString(),
                drink["strInstructions"].GetString(),
                drink["strDrinkThumb"].GetString(),
                GetIngredients(drink))
        );

        foreach(var drink in drinks)
        {
            _memoryCache.Set(drink.id, drink);
        }

        return drinks.ToList();
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
        return _memoryCache.Get<Cocktail>(id);
    }
}
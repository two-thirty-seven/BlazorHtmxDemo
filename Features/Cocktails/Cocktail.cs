namespace BlazorHtmxDemo.Features.Cocktails;

public record Cocktail(int Id, string Name, string Glass, string Instructions, string Thumbnail, IEnumerable<Ingredient> Ingredients) { }
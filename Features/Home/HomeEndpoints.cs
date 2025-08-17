using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BlazorHtmxDemo.Features.Home;

public class HomeEndpoints : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/love-htmx", () => new RazorComponentResult<LoveHtmx>());
        
        app.MapGet("/Person", () => new RazorComponentResult<Person>());
        app.MapGet("/Person/{Id:int}", (int id) => new RazorComponentResult<Person>(new
        {
            Model = new PersonRecord(id, "John", "Doe" )
        }));
        app.MapPost("/Person", ([FromForm] PersonRecord viewModel) => new RazorComponentResult<Person>(new
        {
            Model = viewModel with { PersonId = viewModel.PersonId + 1 } 
        }));
        app.MapDelete("/Person/{Id:int}", (int id) => new RazorComponentResult<Person>());
    }
}

public class PersonModel
{
    public int PersonId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}

public record PersonRecord(int PersonId, string FirstName, string LastName);
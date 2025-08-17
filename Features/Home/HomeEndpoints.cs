using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BlazorHtmxDemo.Features.Home;

public class HomeEndpoints : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/love-htmx", () => new RazorComponentResult<LoveHtmx>());

        app.MapGet("/person-list", (HttpContext context) =>
        {
            var peopleData = context.Session.GetObjectFromJson<List<PersonRecord>>();
            return new RazorComponentResult<PeopleList>(new
            {
                People = peopleData
            });
        });
        
        app.MapGet("/person", () => new RazorComponentResult<Person>(new 
        {
            Model = new PersonRecord(0, "", "")
        }));
        
        app.MapPost("/person", ([FromForm] PersonRecord viewModel, HttpContext context)  =>
        {
            var peopleData = context.Session.GetObjectFromJson<List<PersonRecord>>();
            peopleData.Add(viewModel with { PersonId = peopleData.Count + 1 });
            context.Session.SetObjectAsJson<List<PersonRecord>>(peopleData);
            
            context.Response.Headers.Append("HX-Trigger", "person-list-updated");
            return new RazorComponentResult<Person>(new
            {
                Model = new PersonRecord(0, "", "")
            });
        });

        app.MapDelete("/person/{Id:int}", (int id, HttpContext context) =>
        {
            var peopleData = context.Session.GetObjectFromJson<List<PersonRecord>>();
            peopleData.RemoveAll(p => p.PersonId == id);
            context.Session.SetObjectAsJson<List<PersonRecord>>(peopleData);

            context.Response.Headers.Append("HX-Trigger", "person-list-updated");
            return new RazorComponentResult<Person>(new
            {
                Model = new PersonRecord(0, "", "")
            });
        });
    }
}

public class PersonModel
{
    public int PersonId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}

public record PersonRecord(int PersonId, string FirstName, string LastName);
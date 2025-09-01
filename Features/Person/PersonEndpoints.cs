using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BlazorHtmxDemo.Features.Person;

public class PersonEndpoints : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("/person", () => new RazorComponentResult<PersonForm>(new 
        {
            Model = new PersonRecord(0, "", "")
        }));
        
        app.MapGet("/person-list", (HttpContext context) =>
        {
            var peopleData = context.Session.GetObjectFromJson<List<PersonRecord>>();
            return new RazorComponentResult<PeopleList>(new
            {
                People = peopleData
            });
        });
       
        app.MapPost("/person", ([FromForm] PersonRecord viewModel, HttpContext context)  =>
        {
            var peopleData = context.Session.GetObjectFromJson<List<PersonRecord>>();
            peopleData.Add(viewModel with { PersonId = peopleData.Count + 1 });
            context.Session.SetObjectAsJson<List<PersonRecord>>(peopleData);
            
            context.Response.Headers.Append("HX-Trigger", "person-list-updated");
            return new RazorComponentResult<PersonForm>(new
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
            return new RazorComponentResult<PersonForm>(new
            {
                Model = new PersonRecord(0, "", "")
            });
        });
    }
}

public record PersonRecord(int PersonId, string FirstName, string LastName);
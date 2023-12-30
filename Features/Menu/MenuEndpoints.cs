using BlazorHtmxDemo.Features.Menu;
using Microsoft.AspNetCore.Http.HttpResults;
using static BlazorHtmxDemo.Features.Menu.PageLinks;

public static class MenuEndpoints
{
    public static WebApplication MapMenuEndpoints(this WebApplication app)
    { 
        app.MapGet("/api/links/{popupState}", (PopupMode popupState) => new RazorComponentResult<PageLinks>(new { PopupState = popupState }));

        return app;
    }
}
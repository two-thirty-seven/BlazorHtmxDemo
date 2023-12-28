using BlazorHtmxDemo.Components;
using BlazorHtmxDemo.Components.Partials;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddControllers();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();
app.UseSession();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapControllers();
app.MapGet("/api/love-htmx", () => new RazorComponentResult<LoveHtmx>());
app.MapGet("/api/weather", () => new RazorComponentResult<WeatherTable>());
// app.MapGet("/api/counter", () => new RazorComponentResult<CurrentCount>());
// app.MapPost("/api/counter/increment", (HttpContext context) => {
//     int? currentCount = context.Session.GetInt32("CurrentCount");
//     if (currentCount.HasValue)
//     {
//         currentCount++;
//     }
//     else {
//        currentCount = 0; 
//     }
//     context.Session.SetInt32("CurrentCount", currentCount.Value);
//     context.Response.Headers.Add("HX-Trigger", "counter-updated");

//     return Results.Ok();
// });

app.Run();

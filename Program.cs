using BlazorHtmxDemo.Components;
using BlazorHtmxDemo.Components.Partials;
using Microsoft.AspNetCore.Http.HttpResults;
using static BlazorHtmxDemo.Components.Partials.PageLinks;

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

app.MapEndpoints()
    .MapCounterEndpoints();

app.Run();

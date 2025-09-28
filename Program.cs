using BlazorHtmxDemo.Components;
using BlazorHtmxDemo.Extensions;
using BlazorHtmxDemo.Features.Cocktails;
using BlazorHtmxDemo.Features.Photos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMemoryCache();
builder.Services.AddHttpClient();
builder.Services.AddTransient<CocktailsService>();
builder.Services.AddTransient<PhotosService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddRazorComponents();
builder.Services.AddControllers();
builder.Services.AddEndpoints(typeof(Program).Assembly);
builder.Services.AddAntiforgery();

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
app.MapStaticAssets();
app.UseAntiforgery();
app.UseSession();
app.MapRazorComponents<App>();
app.MapControllers();
app.MapEndpoints();

app.Run();

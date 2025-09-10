using System.Globalization;
using TheRestaurantMvc.ActionFilters;
using TheRestaurantMvc.Clients;
using TheRestaurantMvc.Services;
using TheRestaurantMvc.Services.IServices;

var cultureInfo = new CultureInfo("en-US");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient(); // Registers IHttpClientFactory

builder.Services.AddScoped<IRestaurantApiClient, RestaurantApiClient>(provider =>
{
    var httpClientFactory = provider.GetRequiredService<IHttpClientFactory>();
    var httpClient = httpClientFactory.CreateClient();
    httpClient.BaseAddress = new Uri("https://localhost:44304/api/");
    return new RestaurantApiClient(httpClient);
});

builder.Services.AddScoped<IMenuItemService, MenuItemService>();
builder.Services.AddScoped<JwtAuthenticActionFilter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
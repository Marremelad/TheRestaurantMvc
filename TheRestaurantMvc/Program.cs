using TheRestaurantMvc.ActionFilters;
using TheRestaurantMvc.Clients;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// builder.Services.AddHttpClient("TheRestaurantApi", client =>
// {
//     client.BaseAddress = new Uri("https://localhost:44304/api/");
// });

// builder.Services.AddScoped<IRestaurantApiClient, RestaurantApiClient>();

builder.Services.AddHttpClient(); // Registers IHttpClientFactory

builder.Services.AddScoped<IRestaurantApiClient, RestaurantApiClient>(provider =>
{
    var httpClientFactory = provider.GetRequiredService<IHttpClientFactory>();
    var httpClient = httpClientFactory.CreateClient();
    httpClient.BaseAddress = new Uri("https://localhost:44304/api/");
    return new RestaurantApiClient(httpClient);
});

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
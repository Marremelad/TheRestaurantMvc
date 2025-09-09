using Microsoft.AspNetCore.Mvc;
using TheRestaurantMvc.ActionFilters;
using TheRestaurantMvc.Clients;
using TheRestaurantMvc.Models;

namespace TheRestaurantMvc.Controllers;

[ServiceFilter<JwtAuthenticActionFilter>]
public class HomeController(IRestaurantApiClient client) : Controller
{
    public async Task<IActionResult> Index()
    {
        var response = await client.TheRestaurantApiClient().GetAsync("menu-items");
        return View(await response.Content.ReadFromJsonAsync<ApiResponse<List<MenuItem>>>());
    }
}

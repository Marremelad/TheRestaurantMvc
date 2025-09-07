using Microsoft.AspNetCore.Mvc;
using TheRestaurantMvc.ActionFilters;
using TheRestaurantMvc.Models;
using TheRestaurantMvc.Utilities;

namespace TheRestaurantMvc.Controllers;

[ServiceFilter<JwtAuthenticActionFilter>]
public class HomeController(RegisteredClients clients) : Controller
{
    public async Task<IActionResult> Index()
    {
        var response = await clients.TheRestaurantApiClient().GetAsync("menu-items");
        var menuResponse = await response.Content.ReadFromJsonAsync<ApiResponse<List<MenuItem>>>();
        return View(menuResponse);
    }
}

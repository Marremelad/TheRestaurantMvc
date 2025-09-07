using Microsoft.AspNetCore.Mvc;
using TheRestaurantMvc.ActionFilters;
using TheRestaurantMvc.Models;
using TheRestaurantMvc.Utilities;

namespace TheRestaurantMvc.Controllers;

[ServiceFilter<JwtAuthenticActionFilter>]
public class MenuController(RegisteredClients clients) : Controller
{
    public async Task<IActionResult> Index()
    {
        var response = await clients.TheRestaurantApiClient().GetAsync("menu-items");
        return View(await response.Content.ReadFromJsonAsync<ApiResponse<List<MenuItem>>>());
    }
}
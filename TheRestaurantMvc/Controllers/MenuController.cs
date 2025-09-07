using Microsoft.AspNetCore.Mvc;
using TheRestaurantMvc.HttpClients;
using TheRestaurantMvc.Models;

namespace TheRestaurantMvc.Controllers;

public class MenuController(RegisteredClients clients) : Controller
{
    public async Task<IActionResult> Index()
    {
        var response = await clients.TheRestaurantApiClient().GetAsync("menu-items");
        return View(await response.Content.ReadFromJsonAsync<ApiResponse<List<MenuItem>>>());
    }
}
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TheRestaurantMvc.Models;

namespace TheRestaurantMvc.Controllers;

public class HomeController(IHttpClientFactory clientFactory) : Controller
{
    private readonly HttpClient _client = clientFactory.CreateClient("TheRestaurantApi");

    public async Task<IActionResult> Index()
    {
        var response = await _client.GetAsync("menu-items");
        var menuItems =  await response.Content.ReadFromJsonAsync<ApiResponse<List<MenuItem>>>();
        
        return View(menuItems?.Value);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
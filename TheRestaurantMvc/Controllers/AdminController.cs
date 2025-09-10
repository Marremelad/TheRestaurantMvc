using Microsoft.AspNetCore.Mvc;
using TheRestaurantMvc.ActionFilters;
using TheRestaurantMvc.Clients;
using TheRestaurantMvc.Models.ViewModels;
using TheRestaurantMvc.Services.IServices;

namespace TheRestaurantMvc.Controllers;

[ServiceFilter<JwtAuthenticActionFilter>]
public class AdminController(
    IMenuItemService service,
    IRestaurantApiClient client) : Controller
{
    public async Task<IActionResult> Menu() => View(await service.GetMenuItemsAsync());
    
    public IActionResult CreateMenuItem() => View();
    [HttpPost]
    public async Task<IActionResult> CreateMenuItem(MenuItemCreateViewModel viewModel)
    {
        await client.TheRestaurantApiClient().PostAsJsonAsync("menu-items", viewModel);
        return RedirectToAction("Menu", "Admin");
    }
    
    public async Task<IActionResult> UpdateMenuItem(int id) => View(await service.GetMenuItemByIdAsync(id));
    [HttpPost]
    public async Task<IActionResult> UpdateMenuItem(int id, MenuItemUpdateViewModel model)
    {
        await client.TheRestaurantApiClient().PatchAsJsonAsync($"menu-items/{id}", model);
        return RedirectToAction("Menu", "Admin");
    }
}
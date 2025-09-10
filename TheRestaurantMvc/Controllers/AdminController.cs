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

    public async Task<IActionResult> EditMenuItem(int id) => View(await service.GetMenuItemByIdAsync(id));

    public async Task<IActionResult> Update(int id, MenuItemUpdateViewModel model)
    {
        await client.TheRestaurantApiClient()
            .PatchAsJsonAsync($"menu-items/{id}", model);
        
        return RedirectToAction("Menu", "Admin");
    }
}
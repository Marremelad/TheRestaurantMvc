using Microsoft.AspNetCore.Mvc;
using TheRestaurantMvc.ActionFilters;
using TheRestaurantMvc.Services.IServices;

namespace TheRestaurantMvc.Controllers;

[ServiceFilter<JwtAuthenticActionFilter>]
public class AdminController(IMenuItemService service) : Controller
{
    public async Task<IActionResult> Menu() => View(await service.GetMenuItemsAsync());

    public async Task<IActionResult> EditMenuItem(int id) => View(await service.GetMenuItemByIdAsync(id));
}
using Microsoft.AspNetCore.Mvc;
using TheRestaurantMvc.ActionFilters;
using TheRestaurantMvc.Services.IServices;

namespace TheRestaurantMvc.Controllers;

[ServiceFilter<JwtAuthenticActionFilter>]
public class MenuItemsController(IMenuItemService service) : Controller
{
    public async Task<IActionResult> Index() => View(await service.GetMenuItemsAsync());
    
    public async Task<IActionResult> AdminIndex() => View(await service.GetMenuItemsAsync());

    public async Task<IActionResult> Edit(int id) => View(await service.GetMenuItemByIdAsync(id));

}

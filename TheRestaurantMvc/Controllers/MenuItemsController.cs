using Microsoft.AspNetCore.Mvc;
using TheRestaurantMvc.ActionFilters;
using TheRestaurantMvc.Services.IServices;

namespace TheRestaurantMvc.Controllers;


public class MenuItemsController(IMenuItemService service) : Controller
{
    public async Task<IActionResult> Index() => View(await service.GetMenuItemsAsync());
}

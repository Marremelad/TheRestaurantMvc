using Microsoft.AspNetCore.Mvc;
using TheRestaurantMvc.ActionFilters;
using TheRestaurantMvc.Services.IServices;

namespace TheRestaurantMvc.Controllers;

// [ServiceFilter<JwtAuthenticActionFilter>]
public class HomeController(IMenuItemService service) : Controller
{
    public async Task<IActionResult> Index() => View(await service.GetMenuItemsAsync());
}

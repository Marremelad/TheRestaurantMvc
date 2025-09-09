using Microsoft.AspNetCore.Mvc;
using TheRestaurantMvc.ActionFilters;
using TheRestaurantMvc.Clients;
using TheRestaurantMvc.Models;
using TheRestaurantMvc.Services;
using TheRestaurantMvc.Services.IServices;

namespace TheRestaurantMvc.Controllers;

[ServiceFilter<JwtAuthenticActionFilter>]
public class MenuController(IMenuItemService service) : Controller
{
    public async Task<IActionResult> Index() => View(await service.GetMenuItemsAsync());
    
    public async Task<IActionResult> AdminMenu() => View(await service.GetMenuItemsAsync());
    
}

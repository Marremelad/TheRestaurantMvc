using Microsoft.AspNetCore.Mvc;
using TheRestaurantMvc.ActionFilters;
using TheRestaurantMvc.Services.IServices;

namespace TheRestaurantMvc.Controllers;

public class HomeController(IMenuItemService service) : Controller
{
    public async Task<IActionResult> Index()
    {
        if (HttpContext.Request.Cookies.ContainsKey("jsonWebToken"))
        {
            return RedirectToAction("Menu", "Admin");
        }
        
        var response = await service.GetMenuItemsAsync();
        return View(response);
    }
}

using Microsoft.AspNetCore.Mvc;
using TheRestaurantMvc.ActionFilters;
using TheRestaurantMvc.Clients;
using TheRestaurantMvc.Models;
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

    [HttpPost]
    public async Task<IActionResult> DeleteMenuItem(int id)
    {
        await client.TheRestaurantApiClient().DeleteAsync($"menu-items/{id}");
        return RedirectToAction("Menu", "Admin");
    }
    
    public async Task<IActionResult> Reservations()
    {
        var response = await client.TheRestaurantApiClient().GetAsync("reservations");
        var reservationsResponse = await response.Content.ReadFromJsonAsync<ApiResponse<List<Reservation>>>();

        return View(reservationsResponse);
    }
    
    [HttpPost]
    public async Task<IActionResult> DeleteReservation(int id)
    {
        await client.TheRestaurantApiClient().DeleteAsync($"reservations/{id}");
        return RedirectToAction("Reservations", "Admin");
    }
    
    public async Task<IActionResult> Tables()
    {
        var response = await client.TheRestaurantApiClient().GetAsync("tables");
        var tablesResponse = await response.Content.ReadFromJsonAsync<ApiResponse<List<Table>>>();

        return View(tablesResponse);
    }

    public IActionResult CreateTable() => View() ; 
    [HttpPost]
    public async Task<IActionResult> CreateTable(TableCreateViewModel viewModel)
    {
        await client.TheRestaurantApiClient().PostAsJsonAsync("tables", viewModel);
        return RedirectToAction("Tables", "Admin");
    }

    public async Task<IActionResult> UpdateTable(int id, TableUpdateViewModel viewModel)
    {
        await client.TheRestaurantApiClient().PatchAsJsonAsync($"tables/{id}", viewModel);
        return RedirectToAction("Tables", "Admin");
    }
    
    [HttpPost]
    public async Task<IActionResult> DeleteTable(int id)
    {
        await client.TheRestaurantApiClient().DeleteAsync($"tables/{id}");
        return RedirectToAction("Tables", "Admin");
    }
}
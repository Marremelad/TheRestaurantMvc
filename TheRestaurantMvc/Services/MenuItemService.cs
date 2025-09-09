using TheRestaurantMvc.Clients;
using TheRestaurantMvc.Models;
using TheRestaurantMvc.Services.IServices;

namespace TheRestaurantMvc.Services;

public class MenuItemService(IRestaurantApiClient client) : IMenuItemService
{
    public async Task<ApiResponse<List<MenuItem>>> GetMenuItemsAsync()
    {
        var response = await client.TheRestaurantApiClient().GetAsync("menu-items");
        return (await response.Content.ReadFromJsonAsync<ApiResponse<List<MenuItem>>>())!;
    }

    public async Task<ApiResponse<MenuItem?>> GetMenuItemByIdAsync(int id)
    {
        var response = await client.TheRestaurantApiClient().GetAsync($"menu-items/{id}");
        return (await response.Content.ReadFromJsonAsync<ApiResponse<MenuItem>>())!;
    }
}
using TheRestaurantMvc.Models;

namespace TheRestaurantMvc.Services.IServices;

public interface IMenuItemService
{
    Task<ApiResponse<List<MenuItem>>> GetMenuItemsAsync();
}
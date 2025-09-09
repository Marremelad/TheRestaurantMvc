using TheRestaurantMvc.Models;

namespace TheRestaurantMvc.Services.IServices;

public interface IMenuItemService
{
    Task<ApiResponse<List<MenuItem>>> GetMenuItemsAsync();

    Task<ApiResponse<MenuItem?>> GetMenuItemByIdAsync(int id);
}
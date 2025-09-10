namespace TheRestaurantMvc.Models.ViewModels;

public record MenuItemUpdateViewModel(
    string Name,
    decimal Price,
    string Description,
    string Image,
    bool IsPopular 
    );

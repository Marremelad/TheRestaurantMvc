namespace TheRestaurantMvc.Models;

public record MenuItem(
    int Id,
    string Name,
    decimal Price,
    string Description,
    string Image,
    bool IsPopular
    );